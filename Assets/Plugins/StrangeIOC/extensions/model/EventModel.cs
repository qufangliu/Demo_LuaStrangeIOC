using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Plugins.strange.extensions.model
{
    public class EventModel
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher{ get; set;}

        public void Dispatch( object eventType, object data = null )
        {
            if( data != null )
            {
                dispatcher.Dispatch( eventType, data );
            }
            else
            {
                dispatcher.Dispatch( eventType );
            }
        }
    }
}