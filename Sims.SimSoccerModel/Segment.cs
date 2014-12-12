using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Segment
    {
        int _start;
        int _end;

        public int Start
        {
            get { return _start; }
        }
        public int End
        {
            get { return _end; }
        }

        /// <summary>
        /// Creation a new segment in 1 dimension. Order of parameters is not important.
        /// </summary>
        /// <param name="start">Where does the segment start.</param>
        /// <param name="end">Where does the segment end.</param>
        public Segment( int start, int end )
        {
            if( start > end )
            {
                _start = end;
                _end = start;
            }
            else
            {
                _start = start;
                _end = end;
            }
        }

        public int Length()
        {
            if( ( _start - _end ) >= 0 )
                return ( _start - _end );
            else
                return ( _start - _end );
        }

        public bool IsDotInSegment( int dot )
        {
            if( _start <= dot && dot <= _end )
                return true;
            else
                return false;
        }

        public void Moove( int moove )
        {
            _start += moove;
            _end += moove;
        }

        public bool IsEqual( Segment seg )
        {
            if( ( _start == seg._start ) && ( _end == seg._end ) )
                return true;
            else
                return false;
        }

        public bool IsSuperposed( Segment seg )
        {
            for( int i = _start; i <= _end; i++ )
            {
                for( int j = seg._start; j <= seg._end; j++ )
                {
                    if( i == j )
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get the intersection from 2 segments.
        /// </summary>
        /// <param name="seg">Exept a valid segment wich have intersection with the other one. Use the method bool IsSuperposed( Segment ) to know if they are compatible</param>
        /// <returns>New segment wich is the intersection of both others.</returns>
        public Segment Intersection( Segment seg )
        {
            int start, end;
            if( !( this.IsSuperposed( seg ) ) )
                throw new ArgumentException( "There is no intersection ! Rtfm wtf !" );

            if( _start < seg._start )
                start = seg._start;
            else
                start = _start;
            if( _end < seg._end )
                end = _end;
            else
                end = seg._end;

            return new Segment( start, end );
        }

    }
}
