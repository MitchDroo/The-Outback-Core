using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class CombatOptionSelectorShould
    {
        private ICombatOptionSelectorView _view;
        private CombatOptionSelector _selector;
        private List<ICombatOption> _options;
        
        [SetUp]
        public void Setup()
        {
            _view = Substitute.For<ICombatOptionSelectorView>();
            _options = new List<ICombatOption>();
            _selector = new CombatOptionSelector(_view, _options);
        }
        
        [Test]
        public void Show_Ui_When_Open()
        {
            _selector.Open();

            _view.Received().Show();
        }

        [Test]
        public void Pass_Combat_Options_To_Ui_When_Open()
        {
            _selector.Open();

            _view.Received().Options = _options;
        }

        [Test]
        public void Warn_Ui_When_Selecting_With_Nothing_Selected()
        {
            _view.Selected.ReturnsNull();

            _selector.Open();
            _selector.SelectOption();

            _view.Received().Warn("No combat option selected!");
        }

        [Test]
        public void Execute_Combat_Option_When_Selected()
        {
            var option = Substitute.For<ICombatOption>();
            _view.Selected.Returns(option);
            
            _selector.Open();
            _selector.SelectOption();

            option.Received().Execute();
        }

        [Test]
        public void Close_Menu_When_Selected()
        {
            var option = Substitute.For<ICombatOption>();
            _view.Selected.Returns(option);
            
            _selector.Open();
            _selector.SelectOption();
            
            _view.Received().Hide();
        }

        [Test]
        public void Hide_Ui_When_Closed()
        {
            _selector.Close();

            _view.Received().Hide();
        }
    }
}