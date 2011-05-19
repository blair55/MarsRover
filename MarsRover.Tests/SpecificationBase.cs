using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace MarsRover.Tests
{
    public abstract class using_a_<SUT> : SpecificationBase
    {
        protected SUT system_under_test;

        public using_a_()
        {
            system_under_test = default(SUT);
        }
    }

    [TestFixture]
    public abstract class SpecificationBase
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }

        public abstract void Given();
        public abstract void When();

        public T stub_a<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }
        
        public T mock_a<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }

    public class ThenAttribute : TestAttribute { }
}