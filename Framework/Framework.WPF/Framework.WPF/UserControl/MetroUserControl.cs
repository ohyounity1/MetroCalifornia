using System.ComponentModel;
using System.Windows;
using Stateless;
using Framework.State.Stateless;

using Controls = System.Windows.Controls;

namespace Framework.WPF.UserControl
{
    using System;
    using static Stateless.StateMachine<MetroUserControl.UserControlStates, MetroUserControl.UserControlStateTriggers>;

    /// <summary>
    /// A helper class for common user control method
    /// </summary>
    public abstract class MetroUserControl : Controls.UserControl
    {
        /// <summary>
        /// User control states
        /// </summary>
        public enum UserControlStates
        {
            Void, // Initial state
            NotLoaded, // Not loaded state
            Loaded // Loaded state
        }

        /// <summary>
        /// Triggers for load state
        /// </summary>
        public enum UserControlStateTriggers
        {
            Load, // Load trigger
            Unload // Unload trigger
        }

        /// <summary>
        /// Our load/unload state machine
        /// </summary>
        private readonly StateMachine<UserControlStates, UserControlStateTriggers> _userControlStateMachine;

        /// <summary>
        /// Initializes a new instance of <see cref="MetroUserControl"/>
        /// </summary>
        public MetroUserControl()
        {
            // Create our state machine with the initial state
            _userControlStateMachine = new StateMachine<UserControlStates, UserControlStateTriggers>(UserControlStates.Void);
            // On the void state, allow load trigger to move to Loaded state
            _userControlStateMachine.Configure(UserControlStates.Void).Permit(UserControlStateTriggers.Load, UserControlStates.Loaded);
            // On the Loaded state, allow unload trigger to move to NotLoaded state
            _userControlStateMachine.Configure(UserControlStates.Loaded).Permit(UserControlStateTriggers.Unload, UserControlStates.NotLoaded).
                // Ignore load trigger on Loaded state
                Ignore(UserControlStateTriggers.Load).
                // For the loaded state, create specific handlers for coming from the void state
                OnEntry(Tuple.Create<UserControlStates, Action>(UserControlStates.Void, ControlLoadedFirstTime),
                // Create handler for coming from NotLoaded state
                        Tuple.Create<UserControlStates, Action>(UserControlStates.NotLoaded, () => { }));
            // On the NotLoaded state, call UnloadedToLoaded on entry, and permit the transition
            _userControlStateMachine.Configure(UserControlStates.NotLoaded).OnEntry(UnloadedToLoaded).
                Permit(UserControlStateTriggers.Load, UserControlStates.Loaded);

            // Register for events
            Loaded += ControlLoadedEventHandler;
            Unloaded += ControlUnloadedEventHandler;
        }

        /// <summary>
        /// Allow subclass to override
        /// </summary>
        protected virtual void UnloadedToLoaded()
        {
            
        }

        /// <summary>
        /// Allow subclass to override
        /// </summary>
        /// <param name="t">Transition information</param>
        protected virtual void LoadedToUnloaded(Transition t)
        {
        }

        /// <summary>
        /// Allow subclass to override 
        /// </summary>
        protected abstract void ControlLoadedFirstTime();

        /// <summary>
        /// Helper method
        /// </summary>
        protected bool DesignMode => DesignerProperties.GetIsInDesignMode(this);

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">event args</param>
        protected void ControlLoadedEventHandler(object sender, RoutedEventArgs e)
        {
            // Transition to load state
            _userControlStateMachine.Fire(UserControlStateTriggers.Load);
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">event args</param>
        protected void ControlUnloadedEventHandler(object sender, RoutedEventArgs e)
        {
            // Transition to unload state
            _userControlStateMachine.Fire(UserControlStateTriggers.Unload);
        }
    }
}
