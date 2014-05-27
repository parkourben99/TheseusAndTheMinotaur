using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelDesign.Model;


namespace GamePlayer.game
{
    public class GameInstance
    {
        // sprite batch/ collection of sprites to draw
        private SpriteBatch toRender; 
        // the level used as reference to object locations
        private Level myLevel;
        // theseus' location
        private int theseusLocation;
        // minotaurs location
        private int minotaurLocation;
        // theseus and minotaurs last location
        private int theseusLast;
        private int minotaurLast;
        // score & moves
        private int currentScore = 10000;
        private int currentMoves;
        private int currentTime;
        private bool gameState;
        private int spacing;

        public bool GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public int CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }

        public int CurrentMoves
        {
            get { return currentMoves; }
            set { currentMoves = value; }
        }

        public int CurrentScore
        {
            get { return currentScore; }
            set { currentScore = value; }
        }


        public Level MyLevel
        {
            get { return myLevel; }
            set { myLevel = value;
            
            }
        }
      //  private int currentScore;

        public GameInstance(Level level)
        {
            myLevel = level;
            buildCells();
           // currentScore = 0;
            
            //build level
        }
        public GameInstance()
        {
            
        }
        // draw the original level
        public void buildCells()
        {
            GameController.CurrentGame.sizePanel();
            GameController.CurrentGame.setRatio();
            spacing = GameController.CurrentGame.Renderer.Ratio;
            // create a new sprite batch
            toRender = new SpriteBatch();
            int levelSize = ((myLevel.Width - 1) * (myLevel.Height - 1));
            // clear current game board
            GameController.CurrentGame.Renderer.clearAll();
            // for the size of the level
            for (int i = 0; i < ((myLevel.Width -1) * (myLevel.Height - 1)); i += 1)
            {
                // add a blank(tiled) background to the sprite batch
                toRender.addSprite(myLevel.TileSet["Blank"], (i % (myLevel.Width - 1)), (i / (myLevel.Height -1)), 40, 40);
            }
            toRender.addSprite(myLevel.TileSet["Exit"], (myLevel.ExitLocation % myLevel.Width), (myLevel.ExitLocation / myLevel.Height), 40, 40);
            // for every cell in the level
            foreach (Cell cell in myLevel.CellCollection)
            {
                // the cell type as a string for finding textures in tileset dictionary\
                if (!(myLevel.CellCollection.IndexOf(cell) == myLevel.LevelSize))
                {
                    string cellType = cell.Type.ToString();
                    // add the image for each cell into the sprite batch
                    toRender.addSprite(myLevel.TileSet[cellType], getCoords(cell)[0], getCoords(cell)[1], 40, 40);
                }
            }
            // add theseus, minotaur and exit locations to the sprite batch
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width), (theseusLocation / myLevel.Height), 40, 40);
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width), (minotaurLocation / myLevel.Height), 40, 40);
            // draw all the sprites to the screen
            toRender.runBatch();
        }
        // update location of theseus and the minotaur
        public bool updateCharacters()
        {
            // create new sprite batch
            toRender = new SpriteBatch();
            // add a blank tile at theseus' last location to wipe other image
            toRender.addSprite(myLevel.TileSet["Blank"], (theseusLast % myLevel.Width), (theseusLast / myLevel.Height), 40, 40);
            // add the tile at theseus' last location over the blank tile i.e. return it to normal
            toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[theseusLast].Type.ToString()], (theseusLast % myLevel.Width), (theseusLast / myLevel.Height), 40, 40);
            // place theseus at new location
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width), (theseusLocation / myLevel.Height), 40, 40);
            // replace minotaurs last location
            toRender.addSprite(myLevel.TileSet["Blank"], (minotaurLast % myLevel.Width), (minotaurLast / myLevel.Height), 40, 40);
            toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[minotaurLast].Type.ToString()], (minotaurLast % myLevel.Width), (minotaurLast / myLevel.Height), 40, 40);
            // place minotaur at new location
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width), (minotaurLocation / myLevel.Height), 40, 40);
            // draw spritebatch to screen
            toRender.runBatch();
            // check weither game is won or lost
            if (winLose())
            {
                return true;
            }
            return false;
        }
        // set a new level
        public void newLevel(Level level)
        {
            // clear the current level
            GameController.CurrentGame.Renderer.clearAll();
            // set level base as the new level
            myLevel = level;
            // set theseus and minotaur location
            theseusLocation = myLevel.TheseusLocation;
            minotaurLocation = myLevel.MinotaurLocation;
            // build base game board
            buildCells();
            gameState = true;
        }
        // move theseus
        public void moveTheseus(string direction)
        {
            if (gameState)
            {
                // set theseus' last location as location before move
                theseusLast = theseusLocation;
                // which direction is moved in?
                switch (direction)
                {
                    // for each case alter theseus' location appropriately
                    case "up":
                        if (isSpace(direction, true))
                        {
                            theseusLocation -= myLevel.Width;
                            moveMinotaur(2);
                            currentMoves += 1;

                        }
                        break;
                    case "down":
                        if (isSpace(direction, true))
                        {
                            theseusLocation += myLevel.Width;
                            moveMinotaur(2);
                            currentMoves += 1;
                        }
                        break;
                    case "left":
                        if (isSpace(direction, true))
                        {
                            theseusLocation -= 1;
                            moveMinotaur(2);
                            currentMoves += 1;
                        }
                        break;
                    case "right":
                        if (isSpace(direction, true))
                        {

                            theseusLocation += 1;
                            moveMinotaur(2);
                            currentMoves += 1;
                        }
                        break;
                }
            }
        }
        // check if there is space to move for theseus and/or the minotaur
        public bool isSpace(string direction, bool isTheseus)
        {
            // the cell number
            int cellInt;
                // what are we testing for
                if (isTheseus) 
                {
                    cellInt = theseusLocation;
                }
                else
                {
                    cellInt = minotaurLocation;
                }   
            // find the cell at cell number
            Cell cell = myLevel.CellCollection[cellInt];
            // cell for checking down
            Cell cellIntoDown = myLevel.CellCollection[cellInt + myLevel.Width];
            // cell for checking right
            Cell cellIntoRight = myLevel.CellCollection[cellInt + 1];
            // which direction?
            switch (direction)
            {
                    // for the direction return true if there is no wall, return false if there is a wall
                 case "up":
                    if ((cell.Type == CellType.Up) || (cell.Type == CellType.LeftUP))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "down":
                    if ((cellIntoDown.Type == CellType.Up) || (cellIntoDown.Type == CellType.LeftUP))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "left":
                    if ((cell.Type == CellType.Left) || (cell.Type == CellType.LeftUP))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "right":
                    if ((cellIntoRight.Type == CellType.Left) || (cellIntoRight.Type == CellType.LeftUP))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
            return false;
        }
        // returns coorinates as an array from given cell
        public int[] getCoords(Cell cell)
        {
            //get the location of the cell
            int cellInt = myLevel.CellCollection.IndexOf(cell);
            //create array to return
            int[] coords = new int[2];
            // x is equal to the modulus of the cell location by the level width
            coords[0] = cellInt % myLevel.Width;
            // y is equal to the cell location divided by the level height
            coords[1] = cellInt / myLevel.Height;
            return coords;
        }
        // return coordinates from given cell location -> see above
        public int[] getCoords(int cellInt) {
            int[] coords = new int[2];
            coords[0] = cellInt % myLevel.Width;
            coords[1] = cellInt / myLevel.Height;
            return coords;
        }
        // moves the minotaur by amount of times
        public void moveMinotaur(int times)
        {
            // set the moved count to 0
            int count = 0;
            // while the minotaur hasn't moved twice
            while (count < times)
            {
                // get coordinates for theseus and minotaur locations
                int[] theseusCoords = getCoords(myLevel.CellCollection[theseusLocation]);
                int[] minotaurCoords = getCoords(myLevel.CellCollection[minotaurLocation]);
                // set minotaurs last location to current location
                minotaurLast = minotaurLocation;
                // if the minotaurs x location is less than theseus' x, and there is space
                if ((minotaurCoords[0] < theseusCoords[0]) && (isSpace("right", false)))
                {
                    // move the minotaur right one
                    minotaurLocation += 1;
                    // set amount minotaur has moved to plus 1
                    count += 1;
                    // update graphical locations
                    if (updateCharacters())
                    {
                        break;
                    }
                }
                // if the minotaurs x location is greater than theseus' x, and there is space
                else if ((minotaurCoords[0] > theseusCoords[0]) && (isSpace("left", false)))
                {
                    // move minotaur left one
                    minotaurLocation -= 1;
                    count += 1;
                    if (updateCharacters())
                    {
                        break;
                    }
                }
                // if the minotaurs y location is greater than theseus' y, and there is space
                else if ((minotaurCoords[1] > theseusCoords[1]) && (isSpace("up", false)))
                {
                    // move minotaur up
                    minotaurLocation -= myLevel.Width;
                    count += 1;
                    if (updateCharacters())
                    {
                        break;
                    }

                }
                // if the minotaurs y location is less than theseus' y, and there is space
                else if ((minotaurCoords[1] < theseusCoords[1]) && (isSpace("down", false)))
                {
                    // move minotaur down
                    minotaurLocation += myLevel.Width;
                    count += 1;
                    if (updateCharacters())
                    {
                        break;
                    }

                }
                else
                {
                    // if minotaur cant move then do nothing
                    break;
                }
            }
        }
        // check if game is won or lost
        public bool winLose()
        {
            // if theseus is caught by minotaur the you lose
            if (theseusLocation == minotaurLocation) 
            {
                GameController.CurrentGame.winLose("lose");
                return true;
            }
            // if theseus reaches exit location then you win
            else if (theseusLocation == myLevel.ExitLocation)
            {
                GameController.CurrentGame.winLose("win");
                return true;
            }
            return false;
        }


    }
}
