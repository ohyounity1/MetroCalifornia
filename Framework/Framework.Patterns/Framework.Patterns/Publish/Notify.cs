using System.ComponentModel;
using Framework.Patterns.Equality;

namespace Framework.Patterns.Publish
{
    /// <summary>
    /// Interface to implement for when a property changes.  Also implements <see cref="INotifyPropertyChanged"/> as the listener usually needs to forward the result
    /// </summary>
    public interface INotifyListener : INotifyPropertyChanged
    {
        /// <summary>
        /// Property has changed, given the name of the property
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        void PropertyHasChanged(string propertyName);
    }

    /// <summary>
    /// Class that wraps around any time <see cref="T"/> to send out change notification events
    /// </summary>
    /// <typeparam name="T">Type of wrapper</typeparam>
    /// <typeparam name="EP">Equals policy of type <see cref="IEqualsPolicy{T}"/></typeparam>
    public class Notify<T, EP> where EP : IEqualsPolicy<T>, new()
    {
        // Back end field
        private T _value;

        // Name of the property representing this value
        private readonly string _propertyName;
        // Equals policy
        private readonly EP _ep = new EP();
        // Listener
        private readonly INotifyListener _listener;

        /// <summary>
        /// Initializes a new instance of <see cref="Notify{T, EP}"/>
        /// </summary>
        /// <param name="propertyName">Name of property</param>
        /// <param name="listener">Listener</param>
        public Notify(string propertyName, INotifyListener listener)
        {
            _propertyName = propertyName;
            _listener = listener;
        }

        /// <summary>
        /// Set the value or get the value of type <see cref="T"/>
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                // Check with equals policy
                if(!_ep.EqualsTo(_value, value))
                {
                    _value = value;
                    // Notify listener
                    _listener.PropertyHasChanged(_propertyName);
                }
            }
        }
    }

    /// <summary>
    /// Type of <see cref="Notify{T, EP}"/> which uses the <see cref="BasicEqualsPolicy{D}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Notify<T> : Notify<T, BasicEqualsPolicy<T>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Notify{T}"/>
        /// </summary>
        /// <param name="propertyName">Name of property</param>
        /// <param name="listener">Listener</param>
        public Notify(string propertyName, INotifyListener listener) : base(propertyName, listener)
        {
        }
    }
}
