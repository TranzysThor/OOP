namespace Laba9
{
    public class User
    {
        public delegate void ChangeHandler(string msg);
        public event ChangeHandler Notifier;
        private static int _position;
        public static int position
        {
            get => _position;
            set => _position = value;
        }

        private static int _size;
        public static int size
        {
            get => _size;
            set => _size = value;
        }

        public User(int Position, int Size)
        {
            position = Position;
            size = Size;
        }
        public void Move(int offset)
        {
            position += offset;
            Notifier?.Invoke($"Previous position {position - offset}. Current Position {position}");
        }

        public void Shrink(int shrinkCoef)
        {
            size /= shrinkCoef;
            Notifier?.Invoke($"Previous size {size * shrinkCoef}. Current size {size}");
        }
    }
}