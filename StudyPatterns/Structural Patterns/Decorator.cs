using System;
namespace StudyPatterns
{
    #region Decorator Data
    public interface IStudent
    {
        int GetSkillsLevel();
    }

    public class Student : IStudent
    {
        private int _skillsLevel = 5;
        
        public int GetSkillsLevel()
        {
            return _skillsLevel;
        }
    }

    public abstract class BaseDecorator : IStudent
    {
        private IStudent _student;

        public BaseDecorator(IStudent decoratorComponent)
        {
            _student = decoratorComponent;
        }

        public virtual int GetSkillsLevel()
        {
            return _student.GetSkillsLevel();
        }
    }

    public class ProgrammerStudent : BaseDecorator
    {
        public ProgrammerStudent(IStudent decoratorComponent) : base(decoratorComponent) { }

        public override int GetSkillsLevel()
        {
            return base.GetSkillsLevel() + 5;
        }
    }

    public class SingerStudent : BaseDecorator
    {
        public SingerStudent(IStudent decoratorComponent) : base(decoratorComponent) { }

        public override int GetSkillsLevel()
        {
            return base.GetSkillsLevel() + 3;
        }

    }
    
    #endregion

    #region Test
    public class DecoratorTest
    {
        public static void MainProgram()
        {
            IStudent misha = new Student();
            Console.WriteLine($"Base knowledge level: {misha.GetSkillsLevel()}");
            misha = new SingerStudent(misha);
            Console.WriteLine($"Base + singer knowledge level: {misha.GetSkillsLevel()}");
        }
    }
    #endregion
}