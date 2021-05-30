using System.Collections.Generic;

namespace CookingPot.Update
{
    internal static class UpdaterStatic
    {
        internal static List<IUpdatable> Updatables;
        internal static List<IFixedUpdatable> FixedUpdatables;
        internal static List<ILateUpdatable> LateUpdatables;

        public static void AddToUpdatables(IUpdatable updatable)
        {
            Updatables.Add(updatable);
        }
        public static void AddToUpdatables(IFixedUpdatable updatable)
        {
            FixedUpdatables.Add(updatable);
        }
        public static void AddToUpdatables(ILateUpdatable updatable)
        {
            LateUpdatables.Add(updatable);
        }
        
        public static void RemoveFromUpdatables(IUpdatable updatable)
        {
            Updatables.Remove(updatable);
        }
        public static void RemoveFromUpdatables(IFixedUpdatable updatable)
        {
            FixedUpdatables.Remove(updatable);
        }
        public static void RemoveFromUpdatables(ILateUpdatable updatable)
        {
            LateUpdatables.Remove(updatable);
        }
    }
}