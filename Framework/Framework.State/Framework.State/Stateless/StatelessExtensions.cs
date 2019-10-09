using System;
using Framework.Patterns.Exception;
using Stateless;

namespace Framework.State.Stateless
{
    /// <summary>
    /// Extension methods for <see cref="StateMachine{TState, TTrigger}.StateConfiguration"/>
    /// </summary>
    public static class StatelessExtensions
    {
        /// <summary>
        /// Define an entry method for a specific state
        /// </summary>
        /// <typeparam name="TState">Type of the state</typeparam>
        /// <typeparam name="TTrigger">Trigger</typeparam>
        /// <param name="configuration">The state machine's configuration</param>
        /// <param name="transitions">The list of transition methods when a state is entered</param>
        /// <returns></returns>
        public static StateMachine<TState, TTrigger>.StateConfiguration OnEntry<TState, TTrigger>(
            this StateMachine<TState, TTrigger>.StateConfiguration configuration,
            params Tuple<TState, Action>[] transitions)
        {
            // Define the entry methods
            configuration.OnEntry((t) =>
            {
                // Go through each transition method
                foreach(var transition in transitions)
                {
                    // If this is the state we are interested in...
                    if(Equals(transition.Item1, t.Source))
                    {
                        // Call method on state entry
                        transition.Item2();
                        return;
                    }
                }
                // If transition method not defined for this state, throw an exception
                throw new Exception<InvalidOperationException>(new InvalidOperationException($"Invalid transition from {t.Source} to {t.Destination} for trigger {t.Trigger}"));
            });
            return configuration;
        }
    }
}
