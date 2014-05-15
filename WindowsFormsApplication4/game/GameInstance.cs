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
        private SpriteBatch toRender; 
        private Level myLevel;
        private int theseusLocation;
        private int minotaurLocation;
        private int theseusLast;
        private int minotaurLast;
        private int currentScore;
        private int currentMoves;

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

        public void buildCells()
        {
            toRender = new SpriteBatch();
            GameController.CurrentGame.Renderer.clearAll();
            for (int i = 0; i < myLevel.LevelSize; i += 1)
            {
                toRender.addSprite(myLevel.TileSet["Blank"], (i % myLevel.Width) * 40, (i / myLevel.Height)  * 40, 40, 40);
            }
            foreach (Cell cell in myLevel.CellCollection)
            {
                string cellType = cell.Type.ToString();
                toRender.addSprite(myLevel.TileSet[cellType], getCoords(cell)[0] * 40, getCoords(cell)[1] * 40, 40, 40);
            }
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width) * 40, (theseusLocation / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width) * 40, (minotaurLocation / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet["Exit"], (myLevel.ExitLocation % myLevel.Width) * 40, (myLevel.ExitLocation / myLevel.Height) * 40, 40, 40);
            toRender.runBatch();
        }
        public void updateCharacters()
        {
            toRender = new SpriteBatch();
            toRender.addSprite(myLevel.TileSet["Blank"], (theseusLast % myLevel.Width) * 40, (theseusLast / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[theseusLast].Type.ToString()], (theseusLast % myLevel.Width) * 40, (theseusLast / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet["Theseus"], (theseusLocation % myLevel.Width) * 40, (theseusLocation / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet["Blank"], (minotaurLast % myLevel.Width) * 40, (minotaurLast / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet[myLevel.CellCollection[minotaurLast].Type.ToString()], (minotaurLast % myLevel.Width) * 40, (minotaurLast / myLevel.Height) * 40, 40, 40);
            toRender.addSprite(myLevel.TileSet["Minotaur"], (minotaurLocation % myLevel.Width) * 40, (minotaurLocation / myLevel.Height) * 40, 40, 40);
            toRender.runBatch();
            winLose();
        }

        public void newLevel(Level level)
        {
            GameController.CurrentGame.Renderer.clearAll();
            myLevel = level;
            theseusLocation = myLevel.TheseusLocation;
            minotaurLocation = myLevel.MinotaurLocation;
            buildCells();
            GameController.CurrentGame.Timer.Start();
            GameController.CurrentGame.updatePlayer();
        }

        public void moveTheseus(string direction)
        { 
            theseusLast = theseusLocation;
            switch (direction)
            {
                case "up":
                    if (isSpace(direction, true))
                    {
                        theseusLocation -= myLevel.Width;
                        moveMinotaur(2);
                    }
                    break;
                case "down":
                    if (isSpace(direction, true))
                    {
                        theseusLocation += myLevel.Width;
                        moveMinotaur(2);
                    }
                    break;
                case "left":
                    if (isSpace(direction, true)) 
                    {
                        theseusLocation -= 1;
                        moveMinotaur(2);
                    }
                    break;
                case "right":
                    if (isSpace(direction, true))
                    {
                        
                        theseusLocation += 1;
                        moveMinotaur(2);
                    }
                    break;
             }
            updateCharacters();
        }

        public bool isSpace(string direction, bool isTheseus)
        {
            int cellInt;
            
                if (isTheseus) 
                {
                    cellInt = theseusLocation;
                }
                else
                {
                    cellInt = minotaurLocation;
                }   

            Cell cell = myLevel.CellCollection[cellInt];
            Cell cellIntoDown = myLevel.CellCollection[cellInt + myLevel.Width];
            Cell cellIntoRight = myLevel.CellCollection[cellInt + 1];
            switch (direction)
            {
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

        public int[] getCoords(Cell cell)
        {
            int cellInt = myLevel.CellCollection.IndexOf(cell);
            int[] coords = new int[2];
            coords[0] = cellInt % myLevel.Width;
            coords[1] = cellInt / myLevel.Height;
            return coords;
        }

        public int[] getCoords(int cellInt) {
            int[] coords = new int[2];
            coords[0] = cellInt % myLevel.Width;
            coords[1] = cellInt / myLevel.Height;
            return coords;
        }

        public void moveMinotaur(int times)
        {
            int count = 0;
            while (count < times)
            {

                int[] theseusCoords = getCoords(myLevel.CellCollection[theseusLocation]);
                int[] minotaurCoords = getCoords(myLevel.CellCollection[minotaurLocation]);

                minotaurLast = minotaurLocation;
                if ((minotaurCoords[0] < theseusCoords[0]) && (isSpace("right", false)))
                {
                    minotaurLocation += 1;
                    count += 1;
                    updateCharacters();
                }
                else if ((minotaurCoords[0] > theseusCoords[0]) && (isSpace("left", false)))
                {
                    minotaurLocation -= 1;
                    count += 1;
                    updateCharacters();
                }
                else if ((minotaurCoords[1] > theseusCoords[1]) && (isSpace("up", false)))
                {
                    minotaurLocation -= myLevel.Width;
                    count += 1;
                    updateCharacters();

                }
                else if ((minotaurCoords[1] < theseusCoords[1]) && (isSpace("down", false)))
                {
                    minotaurLocation += myLevel.Width;
                    count += 1;
                    updateCharacters();

                }
                else
                {
                    break;
                }
            }
        }

        public void winLose()
        {
            if (theseusLocation == minotaurLocation) 
            {
                GameController.CurrentGame.winLose("lose");
                
            }
            else if (theseusLocation == myLevel.ExitLocation)
            {
                GameController.CurrentGame.winLose("win");
            }
        }


    }
}
