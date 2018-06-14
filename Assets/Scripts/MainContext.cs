using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class MainContext:MVCSContext
{
    protected override void mapBindings()
    {
        base.mapBindings();

        commandBinder.Bind( ContextEvent.START ).To<StartCommand>().Once();
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
    }
}