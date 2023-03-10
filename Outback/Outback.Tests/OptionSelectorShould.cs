using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Outback.Tests
{
    [TestFixture]
    public class OptionSelectorShould
    {
        private List<int> _list;
        private OptionSelector<int> _selector;

        [SetUp]
        public void SetUp()
        {
            _list = new List<int>() { 1, 2, 3, 4 };
            _selector = new OptionSelector<int>(_list);
        }

        [Test]
        public void Be_Initialized_Correctly()
        {
            _selector.Options.Should().Equal(_list);
        }

        [Test]
        public void Start_With_First_Option_In_List_Selected()
        {
            _selector.Selected.Should().Be(1);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Select_Next_Entry(int numberOfSelections)
        {
            GoForwardToNextOption(numberOfSelections);

            var expectedSelectedOption = _list[numberOfSelections];
            _selector.Selected.Should().Be(expectedSelectedOption);
        }

        [Test]
        public void Cannot_Exceed_Maximum_Number_Of_Options()
        {
            GoToLastOption();

            var expectedSelectedOption = _list[_list.Count - 1];
            _selector.Selected.Should().Be(expectedSelectedOption);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Select_Previous_Entry(int numberOfSelections)
        {
            GoToLastOption();
            GoBackwardToPreviousOption(numberOfSelections);

            var expectedSelectedOption = _list[_list.Count - numberOfSelections];
            _selector.Selected.Should().Be(expectedSelectedOption);
        }

        [Test]
        public void Cannot_Go_Under_Minimum_Number_Of_Options()
        {
            GoToLastOption();
            GoToFirstOption();

            var expectedSelectedOption = _list[0];
            _selector.Selected.Should().Be(expectedSelectedOption);
        }

        [Test]
        public void Return_Total_Options()
        {
            _selector.TotalOptions.Should().Be(_list.Count);
        }

        private void GoForwardToNextOption(int numberOfSelections)
        {
            for (var i = 0; i < numberOfSelections; i++)
            {
                _selector.SelectNextEntry();
            }
        }

        private void GoBackwardToPreviousOption(int numberOfSelections)
        {
            for (var i = 1; i < numberOfSelections; i++)
            {
                _selector.SelectPreviousEntry();
            }
        }

        private void GoToFirstOption()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                _selector.SelectPreviousEntry();
            }
        }

        private void GoToLastOption()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                _selector.SelectNextEntry();
            }
        }
    }
}