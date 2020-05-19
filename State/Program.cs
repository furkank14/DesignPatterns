using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);
            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);
            Console.WriteLine(context.GetState());
            Console.ReadLine();

        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetSate(this);
        }

        public override string ToString()
        {
            return "Modifiy";
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetSate(this);
        }

        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetSate(this);
        }

        public override string ToString()
        {
            return "Added";
        }
    }

    class Context
    {
        private IState _state;

        public void SetSate(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
