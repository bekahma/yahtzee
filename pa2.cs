using System; 
using static System.Console; 


namespace pa2
{
	class YahtzeeDice 
	{
		static Random rGen = new Random( ); 
		int d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0; // initialize all dice where zero is "unrolled".  
		
		public void Roll() // roll the first set of dice (when dice = 0).
		{
			if( d1 == 0 ) d1 = rGen.Next( 1, 7 ); // generate a random number from 1 to 6 and setting to dice value. 
			if( d2 == 0 ) d2 = rGen.Next( 1, 7 ); 
			if( d3 == 0 ) d3 = rGen.Next( 1, 7 ); 
			if( d4 == 0 ) d4 = rGen.Next( 1, 7 ); 
			if( d5 == 0 ) d5 = rGen.Next( 1, 7 ); 
		}
		
		public void Unroll( string faces ) 
		{
			if( faces == "all" ) 
			{
				d1 = d2 = d3 = d4 = d5 = 0; // reset all dice back to 0 to reroll. 
			}
			else 
			{
				for( int i = 0; i < faces.Length; i ++) 
				{
					int u = int.Parse( faces[ i ].ToString( ) ); // set dice to 0 to unroll when user requests specific dice.
					bool found = false; 
					if( ! found && d1 == u) { d1 = 0; found = true; }
					if( ! found && d2 == u) { d2 = 0; found = true; }
					if( ! found && d3 == u) { d3 = 0; found = true; }
					if( ! found && d4 == u) { d4 = 0; found = true; }
					if( ! found && d5 == u) { d5 = 0; found = true; }
				}
			}
		}
		
		public int Sum( ) 
		{
			int sum = 0; 
			
			sum = d1 + d2 + d3 + d4 + d5; // add up all dice values. 
			return sum;
		}
		
		public int Sum( int face ) 
		{
			int sum = 0; 
			
			int[ ] dice = new int [ ] { d1, d2, d3, d4, d5 };
			for( int i = 0; i < 5; i ++ ) 
			{
				if( dice[ i ] == face ) sum += face; // add up all face values when dice matches face. 
			}
			
			return sum; 
		}
		
		public bool IsRunOf( int length )
		{
			int[ ] dice = new int [ ] { d1, d2, d3, d4, d5 };
			Array.Sort( dice ); 
			int count = 1; 
			bool sequence = false; // initialize output of method as false. 
			
			for( int i = 1; i < 5; i ++ ) 
			{
				if( dice[ i ] == ( dice[ i-1 ] + 1 )) // add a count if dice is equal to the previous dice plus 1 (incrementing by 1). 
				{
					count ++; 
					
					if( count == length ) sequence = true; // if count is equal to the length of the sequence, return as true. 
				
				}
				else if( dice[ i ] == dice[ i-1 ] ) 
				{
					continue; // loop continues to run if dice is equal to previous dice (case example: 2 3 3 4 5). 
				} 
				else
				{
					count = 1; // resets count back to 1 if the sequence is disrupted (case example: 1 2 3 5 6). 
				}
			}
			
			return sequence; 
		}
		
		public bool IsSetOf( int size ) 
		{ 
			int[ ] dice = new int [ ] { d1, d2, d3, d4, d5 }; 
			Array.Sort( dice ); 
			int count = 1; 
			bool equal = false; // initialize output of method as false. 
			
			for( int i = 1; i < 5; i ++ ) 
			{
				if( dice[ i ] == dice[ i-1 ] ) // add a count if dice is equal to previous dice. 
				{
					count ++; 
					
					if( count == size ) equal = true; // if count is equal to size of sets, return as true. 
					
				} 
				else 
				{
					count = 1; // resets count back to 1 if set is disrupted (case example: 5 5 5 3 3). 
				}
			}
			
			return equal; 
		}
		
		public bool IsFullHouse( ) 
		{
			int[ ] dice = new int [ ] { d1, d2, d3, d4, d5 };
			Array.Sort( dice ); 
			int count = 1; 
			bool fullhouse = false; // initialize output of method as false. 
			
			for( int i = 1; i < 5; i ++ ) 
			{
				if( dice[ i ] == dice[ i-1 ] ) 
				{
					count ++; // add a count if dice is equal to previous dice. 
				} 
				else 
				{
					break; // once dice does not equal to previous dice, break the loop and stop counting. 
				}
			}
			
			if( count == 2 && dice[ 1 ] != dice[ 2 ] && dice[ 2 ] == dice[ 3 ] && dice[ 3 ] == dice[ 4 ] ) // if x x y y y (2 is equal and 3 is equal) where x < y and x != y. 
			{
				fullhouse = true; 
			}
				
			if( count == 3 && dice[ 2 ] != dice[ 3 ] && dice[ 3 ] == dice[ 4 ] ) // if x x x y y (3 is equal and 2 is equal) where x < y and x != y. 
			{
				fullhouse = true; 
			}
			
			return fullhouse;  
		}
		
		public override string ToString( ) // string method to sort the set of dice in order from smallest to largest.
		{
			int[ ] dice = new int[ 5 ] { d1, d2, d3, d4, d5 }; 
			Array.Sort( dice ); 
			return string.Format( "{0} {1} {2} {3} {4}", 
				dice[ 0 ], dice[ 1 ], dice[ 2 ], dice[ 3 ], dice[ 4 ] ); 
		}
		
	}
}
