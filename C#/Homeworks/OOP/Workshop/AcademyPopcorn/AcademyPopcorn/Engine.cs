using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;
        private int Sleep { get; set; }

        public Engine(IRenderer renderer, IUserInterface userInterface,int sleep)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.Sleep = sleep;
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShoothingRacket)
            {
                (this.playerRacket as ShoothingRacket).Shoot();
            }
        }
        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //TODO: we should remove the previous racket from this.allObjects
            this.playerRacket = obj as Racket;
            this.allObjects.Remove(playerRacket as Racket);
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(this.Sleep);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                for (int i = 0; i < this.allObjects.Count; i++)
                {
                    if (this.allObjects[i] is MeteoriteBall)
                    {
                        MeteoriteBall ball = (MeteoriteBall)this.allObjects[i];
                        TrailObject trail = new TrailObject(new MatrixCoords(ball.TopLeft.Row, ball.TopLeft.Col), 3);
                        this.renderer.EnqueueForRendering(trail);
                        this.allObjects.Add(trail);
                    }
                    this.allObjects[i].Update();                   
                    if (this.allObjects[i] is TrailObject)
                    {
                        TrailObject trail = (TrailObject)this.allObjects[i];
                        if (trail.Lifetime < 0)
                        {
                            this.allObjects.Remove(trail);
                            continue;
                        }
                    }
                    
                    this.renderer.EnqueueForRendering(this.allObjects[i]);

                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }
                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
