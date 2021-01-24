using System;
using System.Collections.Generic;

namespace SoftwareDevelopment
{
    public class Samuel
    {
        #region Fields

        private IList<People> _peopleList;
        private IList<Experience> _experienceList;
        private IList<Knowledge> _knowledgeList;
        private int _timesToTry;
        private string _goodJobMessage;
        private string _clearYourMindMessage;

        #endregion

        #region Constructor

        public Samuel(IList<People> peopleList, IList<Experience> experienceList, IList<Knowledge> knowledgeList, 
            int timesToTry, string goodJobMessage, string clearYourMindMessage)
        {
            _peopleList = peopleList;
            _experienceList = experienceList;
            _knowledgeList = knowledgeList;
            _timesToTry = timesToTry;
            _goodJobMessage = goodJobMessage;
            _clearYourMindMessage = clearYourMindMessage;
        }

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Times to try an objective: ");
            int timesToTry;
            while (!int.TryParse(Console.ReadLine(), out timesToTry))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid number");
                Console.WriteLine("Times to try an objective: ");
            }

            Console.WriteLine("Message for a good job: ");
            var goodJobMessage = Console.ReadLine();

            Console.WriteLine("Message for keep it cool and keep trying: ");
            var clearYourMindMessage = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Going for it...");
            var samuel = new Samuel(new List<People>(), new List<Experience>(), new List<Knowledge>(), timesToTry, goodJobMessage, clearYourMindMessage);
            var objectiveResult = samuel.AchieveObjective(new Objective());

            Console.WriteLine();
            Console.WriteLine("Result: " + objectiveResult.Message);

            Console.ReadKey();
        }

        private ObjectiveResult AchieveObjective(Objective objective)
        {
            var accomplished = false;
            var planResultList = new List<PlanResult>();
            var i = 0;

            while (!accomplished && i < _timesToTry)
            {
                i++;

                Plan plan = MakePlan(objective, _peopleList, _experienceList, _knowledgeList);
                PlanResult planResult = GoForIt(plan);
                accomplished = planResult.ObjectiveAccomplished;

                foreach (var people in GetPeopleDidYouMeet())
                    _peopleList.Add(people);

                foreach (var experience in GetExperiencesDidYouGet())
                    _experienceList.Add(experience);

                foreach (var knowledge in GetKnowledgeDidYouGet())
                    _knowledgeList.Add(knowledge);

                planResultList.Add(planResult);
            };

            string message;
            if (accomplished)
                message = _goodJobMessage;
            else
                message = _clearYourMindMessage;

            return new ObjectiveResult
            {
                ObjectiveAccomplished = accomplished,
                PlanResultList = planResultList,
                Message = message
            };
        }

        private IEnumerable<Knowledge> GetKnowledgeDidYouGet()
        {
            return new List<Knowledge>();
        }

        private IEnumerable<Experience> GetExperiencesDidYouGet()
        {
            return new List<Experience>();
        }

        private IEnumerable<People> GetPeopleDidYouMeet()
        {
            return new List<People>();
        }

        private PlanResult GoForIt(Plan plan)
        {
            return new PlanResult
            {
                ObjectiveAccomplished = false
            };
        }

        private Plan MakePlan(Objective objective, IList<People> _peopleList, IList<Experience> _experienceList, IList<Knowledge> _knowledgeList)
        {
            return new Plan();
        }
    }
}
