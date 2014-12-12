using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Zones
    {
        readonly Field _owner;
        public List<Points> _throwIn1;
        public List<Points> _throwIn2;
        public List<Points> _behindGoalLine1;
        public List<Points> _behindGoalLine2;
        public List<Points> _goalZone;

        public Field Field
        {
            get { return _owner; }
        }
        public Zones(Field owner)
        {
            _owner = owner;
            _throwIn1 = new List<Points>();
            _throwIn2 = new List<Points>();
            _behindGoalLine1 = new List<Points>();
            _behindGoalLine2 = new List<Points>();
            _goalZone = new List<Points>();

            int _X = 0;
            int _Y = 0;
            Points _firstThrowInPoints = new Points( _X, _Y );
            for( int _x = 0; _x <= 10; _x++ )
            {
                    _X = _x * 100;
                    _firstThrowInPoints.X = _X;
                    int _y = 6;
                    _Y = _y * 100;
                    _firstThrowInPoints.Y = _Y;
                    _throwIn1.Add( _firstThrowInPoints );
            }

            Points _secondThrowInPoints = new Points( _X, _Y );
            for( int _x = 0; _x <= 10; _x++ )
            {
                _X = _x * 100;
                _secondThrowInPoints.X = _X;
                int _y = 0;
                _Y = _y * 100;
                _secondThrowInPoints.Y = _Y;
                _throwIn2.Add( _secondThrowInPoints );
            }

            Points _firstBehindGoalLinePoints = new Points( _X, _Y );
            for( int _y = 0; _y <= 6; _y++ )
            {
                _Y = _y * 100;
                _firstBehindGoalLinePoints.Y = _Y;
                int _x = 0;
                _X = _x * 100;
                _firstBehindGoalLinePoints.X = _X;
                _behindGoalLine1.Add( _firstBehindGoalLinePoints );
            }

            Points _secondBehindGoalLinePoints = new Points( _X, _Y );
            for( int _y = 0; _y <= 6; _y++ )
            {
                _Y = _y * 100;
                _secondBehindGoalLinePoints.Y = _Y;
                int _x = 10;
                _X = _x * 100;
                _secondBehindGoalLinePoints.X = _X;
                _behindGoalLine2.Add( _secondBehindGoalLinePoints );
            }


            for( int _x = 0; _x < 100; _x++ )
            {
                for( int _y = 0; _y < 600; _y++ )
                {
                    Points _goalZonePoints = new Points( _x, _y );
                    _goalZone.Add( _goalZonePoints );
                }
            }
        }

        public List<Points> ThrowIn1
        {
            get { return _throwIn1; }
        }

        public List<Points> ThrowIn2
        {
            get { return _throwIn2; }
        }

        public List<Points> BehingGoalLine1
        {
            get { return _behindGoalLine1; }
        }
        
        public List<Points> BehingGoalLine2
        {
            get { return _behindGoalLine2; }
        }

        public List<Points> GoalZonePoints
        {
            get { return _goalZone; }
        }
    }
}
