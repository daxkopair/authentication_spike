using System;

namespace app.utility
{
  public class BlockExtensionPoint<BlockType>
  {
    public BlockType block { get; private set; }

    public BlockExtensionPoint(BlockType block)
    {
      this.block = block;
    }
  }

  public static class BlockExtensions
  {
    public static BlockExtensionPoint<Action> with_custom_error_handling(
      this BlockExtensionPoint<Action> extension_point, Action<Exception> error_handler)
    {
      return new BlockExtensionPoint<Action>(() =>
      {
        try
        {
          extension_point.block();
        }
        catch (Exception e)
        {
          error_handler(e);
        }
      });
    }

    public static BlockExtensionPoint<Action> with_custom_exception_throwing(
      this BlockExtensionPoint<Action> extension_point, Func<Exception, Exception> custom_exception_factory)
    {
      return extension_point.with_custom_exception_throwing(custom_exception_factory, x => true);
    }

    public static BlockExtensionPoint<Action> with_custom_exception_throwing(
      this BlockExtensionPoint<Action> extension_point, Func<Exception, Exception> custom_exception_factory,
      Func<Exception, bool> filter)
    {
      return extension_point.with_custom_error_handling(exception =>
      {
        if (filter(exception)) throw custom_exception_factory(exception);
        throw exception;
      });
    }
  }

  public class Wrap
  {
    public static ICreateBlockBuilders builder_factory = new BlockBuilderFactory();

    public static IEnhanceValueReturningCodeBlocks<ReturnType> the_block<ReturnType>(Func<ReturnType> block)
    {
      return builder_factory.create_builder_for(block);
    }

    public static BlockExtensionPoint<Action> an_action(Action action)
    {
      return new BlockExtensionPoint<Action>(action);
    }

    public static BlockExtensionPoint<Func<ReturnType>> an_action<ReturnType>(Func<ReturnType> action)
    {
      //TODO - What would you do here?
      throw new NotImplementedException();
    }
  }
}