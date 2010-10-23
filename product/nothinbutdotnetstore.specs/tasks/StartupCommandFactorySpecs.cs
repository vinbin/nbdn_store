using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
    class StartupCommandFactorySpecs
    {
        public abstract class concern : Observes<StartupCommandFactory, DefaultStartupCommandFactory>
        {

        }

        [Subject(typeof(DefaultStartupCommandFactory))]
        public class when_creating_a_startup_command_from_an_type : concern
        {
            private Establish c = () =>
                                      {
                                          dependency_type = typeof (ourStarupCommmand);
                                          the_correct_startupCommand = an<StartupCommand>();
                                      };

            private Because b = () =>
                                    {
                                        result = sut.create_from(dependency_type);
                                    };

            private It should_be_able_to_create_a_startup_command_from_its_type =
                () => result.ShouldEqual(the_correct_startupCommand);

            static StartupCommand result;
            static Type dependency_type;
            private static StartupCommand the_correct_startupCommand;
        }

        public class ourStarupCommmand : StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }

    }
}
