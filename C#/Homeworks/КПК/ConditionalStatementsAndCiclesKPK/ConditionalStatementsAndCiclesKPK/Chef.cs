using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatementsAndCiclesKPK
{
        public class Chef
        {
            private Bowl GetBowl()
            {
                Bowl bowl = new Bowl(BowlSize.ExtraLarge);
                return bowl;
            }

            private Carrot GetCarrot()
            {
                Carrot carrot = new Carrot();
                return carrot;
            }

            private void Cut(Vegetable vegetable)
            {
                if (vegetable != null)
                {
                    Console.WriteLine("{0} cut", vegetable.GetType().Name);
                }
                else
                {
                    throw new NullReferenceException("Vegetable can not be null");
                }
            }

            private void Peel(Vegetable vegetable)
            {
                if (vegetable != null)
                {
                    Console.WriteLine("{0} peeled", vegetable.GetType().Name);
                }
                else
                {
                    throw new NullReferenceException("Vegetable can not be null");
                }
            }

            public void Cook(Vegetable vegetable)
            {
                Vegetable vegetableToCook;
                switch (vegetable.GetType().Name)
                {
                    case "Carrot":
                        {
                            vegetableToCook = this.GetCarrot();
                            break;
                        }
                    case "Potato":
                        {
                            vegetableToCook = this.GetPotato();
                            break;
                        }
                    default:
                        {
                            throw new VegetableDoesNotExistsException("No such vegetable in the kitchen");
                        }
                }

                Bowl bowl = this.GetBowl();
                bowl.Add(vegetableToCook);
            }

            public void Cook()
            {
                Potato potato = this.GetPotato();
                Carrot carrot = this.GetCarrot();
                Bowl bowl = this.GetBowl();

                this.Peel(potato);
                this.Peel(carrot);
                this.Cut(potato);
                this.Cut(carrot);

                bowl.Add(carrot);
                bowl.Add(potato);
            }

            private Potato GetPotato()
            {
                Potato potato = new Potato();
                return potato;
            }

        }
        

}
