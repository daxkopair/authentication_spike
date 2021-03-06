﻿using System;
using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(ObjectExtensions))]
  public class ObjectExtensionsSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_attempting_to_cast_an_object_to_another_type : concern
    {
      public class and_the_cast_is_valid
      {
        Establish c = () =>
        {
          the_item = new SomeItem();
        };

        It should_return_the_casted_instance = () =>
          (the_item).cast_to<SomeItem>().ShouldBeAn<SomeItem>();

        static object the_item;
      }
      public class and_the_cast_is_invalid
      {
        Establish c = () =>
        {
          the_item = new SomeItem();
        };

        Because b = () =>
          spec.catch_exception(() => the_item.cast_to<int>());


        It should_get_an_invalid_cast_exception = () =>
          spec.exception_thrown.ShouldBeAn<InvalidCastException>();

        static object the_item;
      }
    }

    public class SomeItem
    {
    }
  }
}