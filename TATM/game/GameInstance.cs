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
        public int TheseusLocation
        {
            set { theseusLocation = value; }
        }
        private bool canUndo;
        public bool CanUndo
        {
            set { canUndo = value; }
        }
        // minotaurs location
        private int minotaurLocation;
        public int MinotaurLocation
        {
            set { minotaurLocation = value; }
        }
        // theseus and minotaurs last location
        private int theseusLast;
        private int[] minotaurLast = new int[2];
        // score & moves
        private int currentScore = 10000;
        private int currentMoves;
        private int currentTime;
        private bool gameState;

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

        }
        public GameInstance()
        {
            
        }
        // draw the original level
        public void undo()
        {
            if (canUndo)
            {
                theseusLocation = theseusLast;
                minotaurLocation = minotaurLast[1];
                buildCells();
                currentMoves += 1;
            }
            else
            {
                
            }
            canUndo = false;
        }

        public int checkerGround(int index)
        {
            int x = index % myLevel.Width;
            int y = index / myLevel.Height;

            int ind = ((x + y) % 2) + 1;
            return ind;
        }
        public void buildCells()
        {
            GameController.CurrentGame.setRatio();
            // create a new sprite batch
            toRender = new SpriteBatch();
            // clear current game board
            GameController.CurrentGame.Renderer.clearAll();
            // for the size of the level
            for (int i = 0; i < myLevel.LevelSize; i += 1)
            {
                // add a blank(tiled) background to the sprite batch

                toRender.addSprite(myLevel.TileSet["Ground" + checkerGround(i)], (i % myLevel.Width), (i / myLevel.Height));
            }
            // for every cell in the level
            
            foreach (Cell cell in myLevel.CellCollection)
            {
                // the cell type as a string for finding textures in tileset dictionary
                string cellType = cell.Type.ToString();
                // add the image for each cell into the sprite batch

                if (cellType != CellType.Ground.ToString())
                {
                    toRender.addSprite(myLevel.TileSet[cellType], getCoords(cell)[0], getCoords(cell)[1]);
                }
                else
                {
                    toRender.addSprite(myLevel.TileSet["Ground" + checkerGround(myLevel.CellCollection.IndexOf(cell))], getCoords(cell)[0], getCoords(cell)[1]);
                }
            }
            // add theseus, minotaur and exit locations to the sprite batch
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width), (theseusLocation / myLevel.Height) );
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width), (minotaurLocation / myLevel.Height));
            toRender.addSprite(myLevel.TileSet["Exit"], (myLevel.ExitLocation % myLevel.Width), (myLevel.ExitLocation / myLevel.Height));

            // draw all the sprites to the screen
            toRender.runBatch();
        }
        // update location of theseus and the minotaur
        public bool updateCharacters()
        {
            // create new sprite batch
            toRender = new SpriteBatch();
            // add a blank tile at theseus' last location to wipe other image
            toRender.addSprite(myLevel.TileSet["Ground" + checkerGround(theseusLast)], (theseusLast % myLevel.Width), (theseusLast / myLevel.Height));
            // add the tile at theseus' last location over the blank tile i.e. return it to normal
            if (myLevel.CellCollection[theseusLast].Type != CellType.Ground)
            {
                toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[theseusLast].Type.ToString()], (theseusLast % myLevel.Width), (theseusLast / myLevel.Height));
            }           
            // place theseus at new location
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width), (theseusLocation / myLevel.Height));
            // replace minotaurs last location
            toRender.addSprite(myLevel.TileSet["Ground" + checkerGround(minotaurLast[0])], (minotaurLast[0] % myLevel.Width), (minotaurLast[0] / myLevel.Height));
            if (myLevel.CellCollection[minotaurLast[0]].Type != CellType.Ground)
            {
                toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[minotaurLast[0]].Type.ToString()], (minotaurLast[0] % myLevel.Width), (minotaurLast[0] / myLevel.Height));
            }           
            // place minotaur at new location
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width), (minotaurLocation / myLevel.Height));
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
            theseusLast = myLevel.TheseusLocation;
            minotaurLast[0] = myLevel.MinotaurLocation;
            minotaurLast[1] = myLevel.MinotaurLocation;

            // build base game board
            buildCells();
            gameState = true;
            canUndo = true;
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
                            if (updateCharacters())
                            {
                                break;
                            }
                            moveMinotaur(2);
                            currentMoves += 1;

                        }
                        break;
                    case "down":
                        if (isSpace(direction, true))
                        {
                            theseusLocation += myLevel.Width;
                            if (updateCharacters())
                            {
                                break;
                            }
                            moveMinotaur(2);
                            currentMoves += 1;
                        }
                        break;
                    case "left":
                        if (isSpace(direction, true))
                        {
                            theseusLocation -= 1;
                            if (updateCharacters())
                            {
                                break;
                            }
                            moveMinotaur(2);
                            currentMoves += 1;
                        }
                        break;
                    case "right":
                        if (isSpace(direction, true))
                        {

                            theseusLocation += 1;
                            if (updateCharacters())
                            {
                                break;
                            }
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
            minotaurLast[1] = minotaurLocation;
            // set the moved count to 0
            int count = 0;
            minotaurLast[1] = minotaurLocation;
            // while the minotaur hasn't moved twice
            while (count < times)
            {
                // get coordinates for theseus and minotaur locations
                int[] theseusCoords = getCoords(myLevel.CellCollection[theseusLocation]);
                int[] minotaurCoords = getCoords(myLevel.CellCollection[minotaurLocation]);
                // set minotaurs last location to current location
                minotaurLast[0] = minotaurLocation;
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

        public List<string> getInstance()
        {
            List<string> data = new List<string>();
            data.Add(myLevel.LevelName);
            data.Add(theseusLocation.ToString());
            data.Add(minotaurLocation.ToString());
            data.Add(currentMoves.ToString());
            data.Add(currentTime.ToString());
            data.Add(canUndo.ToString());
            return data;
        }

    }
}
