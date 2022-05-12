using System;

namespace Eventhandler.Lesson
{
    delegate void MoveEventHandler(object source, MoveEventArgs e); // ->> slider_Move

    internal class Program
    { 
        static void Main(string[] args)
        {
             
            Slider slider = new Slider();
            slider.Move += new MoveEventHandler(slider_Move2);
            slider.Position = 25;
            slider.Position = 60; 
        }


        static void slider_Move(object source, MoveEventArgs args)
        {
            if(args.newPosition < 50)
            {
                Console.WriteLine("OK");
            }
            else
            {
                args.cancel = true;
                Console.WriteLine(" non posso andare oltre!");
            }
        }
        static void slider_Move2(object source, MoveEventArgs e)
        {

        }

    }

    public class MoveEventArgs : EventArgs
    {
        public int newPosition;
        public bool cancel; 

        public MoveEventArgs( int NewPosition)
        {
            this.newPosition = NewPosition;
        }
    }
    class Slider
    {
        int position; 
        public event MoveEventHandler Move;  
        public int Position { get { return position; }  set { 
                
            if(position!= value) // if position has changed 
            {
               if(Move != null) 
                {
                   MoveEventArgs args = new MoveEventArgs(value); // ->>> ho passao il nuovo valore 
                   Move(this, args); // --> Chiama Evento

                        if (args.cancel)
                            return; 
                  
                }
                position = value;   // Finish 
            }            
          }  
        }   
        public string Name { get; set; }

    }
}
