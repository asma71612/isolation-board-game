using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static bool[ , ] board; // board game
        static string nameA, nameB; // names of the players
        static int rows, columns; // number of rows and columns the user enters 
        
        static int platformRowA, platformColumnA; // starting platform for A
        static int platformRowB, platformColumnB; // starting platform for B
        
        static int pawnRowA, pawnColumnA; // position of Pawn A
        static int pawnRowB, pawnColumnB; // position of Pawn B
        
        static int checkIfPawnRowA, checkIfPawnColumnA; // moving the pawn
        static int checkIfPawnRowB, checkIfPawnColumnB; // moving the pawn

        static int checkIfRemovableRowA, checkIfRemovableColumnA; // removing the tile      
        static int checkIfRemovableRowB, checkIfRemovableColumnB; // removing the tile
        
        static bool gameRunning = true;
        static bool gameWinner = false;

        static void Main( )
        {
            Initialization( );
            
            // game is running 
            while ( gameRunning || gameWinner )
            {
                DrawGameBoard( );
                MakeMoves( );
            }
            
            // when winner is declared, output the user
            while ( !gameWinner )
            {
                WriteLine ( "Congratulations Player __. You won!" );
            }
        }

        static void MakeMoves( )
        {
            string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            bool isValid = false;

            // player A's turn
            while(!isValid)
            {
                WriteLine( nameA + ", it's your turn");
    
                Write( "Enter 4 letters, pawn row and column, and remove row and column: " ); 
                string move = ReadLine( );

                while (move.Length != 4)
                {
                    Write( "Please enter a 4 letter move: " );
                    move = ReadLine();
                }

                checkIfPawnRowA = Array.IndexOf ( letters, move.Substring( 0, 1 ) ); // first letter
                checkIfPawnColumnA = Array.IndexOf ( letters, move.Substring( 1, 1 ) ); // second letter
                checkIfRemovableRowA = Array.IndexOf ( letters,move.Substring( 2, 1 ) ); // third letter
                checkIfRemovableColumnA = Array.IndexOf ( letters,move.Substring( 3, 1 ) ); // fourth letter
                
                // if the move is outside the board
                while ( checkIfPawnRowA > board.GetLength(0) - 1 || checkIfPawnColumnA > board.GetLength(1) - 1 )
                {
                    WriteLine( "Please enter a move that is within the board: " );
                    move = ReadLine();
                    
                    checkIfPawnRowA = Array.IndexOf ( letters, move.Substring( 0, 1 ) ); // first letter
                    checkIfPawnColumnA = Array.IndexOf ( letters, move.Substring( 1, 1 ) ); // second letter
                    checkIfRemovableRowA = Array.IndexOf ( letters,move.Substring( 2, 1 ) ); // third letter
                    checkIfRemovableColumnA = Array.IndexOf ( letters,move.Substring( 3, 1 ) ); // fourth letter

                    
                }
                
                // to see if Pawn B is on the tile 
                if ( checkIfPawnRowA == pawnRowB && checkIfPawnColumnA == pawnColumnB )
                {
                    WriteLine( "Error! Pawn B is on this Tile" );
                }
                
                // to see if Pawn A is on the tile
                else if ( checkIfPawnRowA == pawnRowA && checkIfPawnColumnA == pawnColumnA )
                {
                    WriteLine( "Error! You are on this tile" );
                }
                
                // to see if the tile is already removed
                else if ( board [ checkIfPawnRowA , checkIfPawnColumnA ] == false )
                {
                    WriteLine( "Error! You can't move to a tile that has been removed" );
                }
                
                // if the move isnt 1 adjacent 
                else if ( (pawnRowA - 1 > checkIfPawnRowA || checkIfPawnRowA > pawnRowA + 1) || 
                          (pawnColumnA - 1 > checkIfPawnColumnA || checkIfPawnColumnA > pawnColumnA + 1) )
                {
                    WriteLine( "Error! You must move only 1 space adjacent" );
                }

                // error checking
                else if ( ( checkIfRemovableRowA == pawnRowA && checkIfRemovableColumnA == pawnColumnA ) ||
                          ( checkIfRemovableRowA == platformRowA && checkIfRemovableColumnA == platformColumnA ) || 
                          ( checkIfRemovableRowA == platformRowB && checkIfRemovableColumnA == platformColumnB ) ||
                          ( checkIfRemovableRowA == checkIfPawnRowA && checkIfRemovableColumnA == checkIfPawnColumnA ) || 
                          ( checkIfRemovableRowA == pawnRowB && checkIfRemovableColumnA == pawnColumnB ) ||
                          ( checkIfRemovableRowA > board.GetLength( 0 ) - 1 || checkIfRemovableColumnA > board.GetLength( 1 ) - 1 ) ||
                          ( board [ checkIfRemovableRowA , checkIfRemovableColumnA]  == false ) )
                {
                    WriteLine( "Error! You cannot remove this tile" );
                }

                else
                {
                    board [ checkIfRemovableRowA , checkIfRemovableColumnA ] = false;
                    isValid = true;
                    pawnRowA = checkIfPawnRowA;
                    pawnColumnA = checkIfPawnColumnA;
                }
            }

            DrawGameBoard();

            isValid = false;
            
            // player B's turn
            while ( !isValid )
            {

                WriteLine( nameB + ", it's your turn" );

                Write( "Enter 4 letters, pawn row and column, and remove row and column: " ); 
                string move = ReadLine( );

                while ( move.Length != 4 )
                {
                    Write( "Please enter a 4 letter move: " );
                    move = ReadLine();
                }

                checkIfPawnRowB = Array.IndexOf ( letters , move.Substring( 0 , 1 ) ); // first letter
                checkIfPawnColumnB = Array.IndexOf ( letters , move.Substring( 1 , 1 ) ); // second letter
                checkIfRemovableRowB = Array.IndexOf ( letters , move.Substring( 2 , 1 ) ); // third letter
                checkIfRemovableColumnB = Array.IndexOf ( letters , move.Substring( 3 , 1 ) ) ; // fourth letter

                // if the move is outside the board
                while ( checkIfPawnRowB > board.GetLength( 0 ) - 1 || checkIfPawnColumnB > board.GetLength( 1 ) - 1 )
                {
                    Write( "Please enter a move that is within the board: " );
                    move = ReadLine();

                    checkIfPawnRowB = Array.IndexOf ( letters , move.Substring( 0 , 1 ) ); // first letter
                    checkIfPawnColumnB = Array.IndexOf ( letters , move.Substring( 1 , 1 ) ); // second letter
                    checkIfRemovableRowB = Array.IndexOf ( letters , move.Substring( 2 , 1 ) ); // third letter
                    checkIfRemovableColumnB = Array.IndexOf ( letters , move.Substring( 3 , 1 ) ) ; // fourth letter
                }

                // to see if Pawn A is on the tile 
                if ( checkIfPawnRowB == pawnRowA && checkIfPawnColumnB == pawnColumnA )
                {
                    WriteLine ( "Error! Pawn A is on this Tile" );
                }
                
                // to see if Pawn B is on the tile
                else if ( checkIfPawnRowB == pawnRowB && checkIfPawnColumnB == pawnColumnB )
                {
                    WriteLine ( "Error! You are on this tile" );
                }
                
                // to see if the tile is already removed
                else if ( board [ checkIfPawnRowB , checkIfPawnColumnB ] == false )
                {
                    WriteLine ( "Error! You can't move to a removed tile" );
                }
                
                // to see if the move is adjacent
                else if ( ( pawnRowB - 1 > checkIfPawnRowB || checkIfPawnRowB > pawnRowB + 1 ) || 
                          ( pawnColumnB - 1 > checkIfPawnColumnB || checkIfPawnColumnB > pawnColumnB + 1 ) )
                {
                    WriteLine( "Error! You must move only 1 space adjacent" );
                }

                // error checking
                else if ( ( checkIfRemovableRowB == pawnRowB && checkIfRemovableColumnB == pawnColumnB )||
                          ( checkIfRemovableRowB == platformRowB && checkIfRemovableColumnB == platformColumnB ) || 
                          ( checkIfRemovableRowB == platformRowA && checkIfRemovableColumnB == platformColumnA ) ||
                          ( checkIfRemovableRowB == checkIfPawnRowB && checkIfRemovableColumnB == checkIfPawnColumnB ) || 
                          ( checkIfRemovableRowB == pawnRowA && checkIfRemovableColumnB == pawnColumnA ) ||
                          ( checkIfRemovableRowB > board.GetLength( 0 ) - 1 || checkIfRemovableColumnB > board.GetLength( 1 ) - 1 ) ||
                          ( board [ checkIfRemovableRowB , checkIfRemovableColumnB ] == false ) )
                {
                    WriteLine( "Error! You cannot remove this tile" );
                }

                else
                {
                    board [ checkIfRemovableRowB , checkIfRemovableColumnB ] = false;
                    isValid = true;
                    pawnRowB = checkIfPawnRowB;
                    pawnColumnB = checkIfPawnColumnB;
                }
            }
        }

        static void Initialization()
        {
            Console.Clear ( );
            
            string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            int[] numbers = new int [26];
            
            for (int a = 0; a < numbers.Length; a++)
            {
                numbers[ a ] = a;
            }
            
            // Collect user input but allow just <Enter> for a default value.
            Write( "Enter your name [default Player A]: " );
            nameA = ReadLine( );
            if( nameA.Length == 0 ) nameA = "Player A";
            WriteLine( "name: {0}", nameA );

            Write( "Enter your name [default Player B]: " );
            nameB = ReadLine( );
            if( nameB.Length == 0 ) nameB = "Player B";
            WriteLine( "name: {0}", nameB );

            // error checking if the number of rows and columns isnt within 4-26
            bool isValid = false;

            while ( isValid == false )
            {
                Write ( "Enter a number for the number of rows [4-26, default 6]: " );
                string response1 = ReadLine( );
                if ( response1.Length == 0 ) rows = 6;
                else rows = int.Parse( response1 );
                if ( rows < 4 || rows > 26 )
                {
                    WriteLine( "The number of rows must be between 4 and 26. " );
                }
                else isValid = true;
            }

            isValid = false;
            
            while ( isValid == false )
            {
                Write( "Enter a number for the number of columns [4-26, default 8]: " );
                string response2 = ReadLine( );
                if ( response2.Length == 0 ) columns = 8;
                else columns = int.Parse( response2 );
                if ( columns < 4 || columns > 26 )
                {
                    WriteLine( "The number of columns must be between 4 and 26. " );
                }
                else isValid = true;
            }


            board = new bool [ rows, columns ];
            
            for( int r = 0; r < rows; r++ )
            {
                for( int s = 0; s < columns; s++ )
                {
                    board[ r, s ] = true;
                }
            } 
            
            // declaring starting position of Pawn A
            Write ( "Enter a letter for Pawn A's platform row or press enter for default: " );
            string response = ReadLine( );

            platformRowA = Array.IndexOf ( letters, response );
                  
            // default values - sets starting position 
            if  (response.Length == 0 )
            {
                platformRowA = pawnRowA = ( int ) Math.Ceiling( ( rows - 1 ) / 2.0 );
                WriteLine ( "The default row is {0}", letters [ platformRowA ]  );
            }
            
            // if the user enters more than one letter
            else if ( response.Length != 1 )
            {
                Write ( "Please enter 1 letter for Pawn A's platform row or press enter for default: " );
                response = ReadLine( );
            }
      
            while ( platformRowA > rows - 1)
            {
                Write( "Enter a valid letter for Pawn A's platform row or press enter for default: " );
                response = ReadLine ( );
                platformRowA = Array.IndexOf ( letters, response );
            }
                        
            Write ( "Enter a letter for Pawn A's platform column or press enter for default: " );
            response = ReadLine( );
            platformColumnA = Array.IndexOf ( letters, response );
            
            if  (response.Length == 0 )
            {
                platformColumnA = 0;
                WriteLine ( "The default row is {0}", letters [ platformColumnA ]  );
            }

            // if the user enters more than one letter
            else if ( response.Length != 1 )
            {
                Write ( "Please enter 1 letter for Pawn A's platform column or press enter for default: " );
                response = ReadLine( );
            }

            while ( platformColumnA > columns - 1)
            {
                Write( "Enter a valid letter for Pawn A's platform column or press enter for default: " );
                response = ReadLine ( );
                platformColumnA = Array.IndexOf ( letters, response );
            }
            
            // declaring starting position of Pawn B
            Write( "Enter a Letter for Pawn B's Platform Row or Press Enter: " );
            response = ReadLine( );
            platformRowB = Array.IndexOf(letters, response);
            
            // default values - sets starting position 
            if ( response.Length == 0 )
            {
                platformRowB = pawnRowB = ( int ) Math.Ceiling( ( rows - 1 ) / 2.0 + 1.0 );
                WriteLine("The default row is {0}", letters[ platformRowB ] );
            }

            // if the user enters more than one letter
            else if ( response.Length != 1 )
            {
                Write ( "Please enter 1 letter for Pawn B's platform row or press enter for default: " );
                response = ReadLine( );
            }
            
            while ( platformRowB > rows - 1 || platformRowB == platformRowA )
            {
                Write( "Enter a Valid Letter for Pawn B's Platform Row or Press Enter: " );
                response = ReadLine( );
                platformRowB = Array.IndexOf( letters, response );
            }
            
            Write( "Enter a Letter for Pawn B's Platform Column or Press Enter: " );
            response = ReadLine( );
            platformColumnB = Array.IndexOf(letters, response);
            
            // default values
            if ( response.Length == 0 )
            {
                platformColumnB = board.GetLength( 1 ) - 1;
                WriteLine( "The default row is {0}", letters[ platformColumnB ] );
            }
            
            // if the user enters more than one letter
            else if ( response.Length != 1 )
            {
                Write ( "Please enter 1 letter for Pawn B's platform column or press enter for default: " );
                response = ReadLine( );
            }
            
            while ( platformColumnB > columns - 1 || platformColumnB == platformColumnA )
            {
                Write( "Enter a Valid Letter for Pawn B's Platform Row or Press Enter: " );
                response = ReadLine( );
                platformColumnB = Array.IndexOf( letters, response );
            }

            pawnRowA = platformRowA;
            pawnColumnA = platformColumnA;
            pawnRowB = platformRowB;
            pawnColumnB = platformColumnB;
        }

        static void DrawGameBoard( )
        {
            Console.Clear();
            
            const string h  = "\u2500"; // horizontal line
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
            //const string sp = " ";   // space
            //const string pa = "A";      // pawn A
            //const string pb = "B";      // pawn B
            const string bb = "\u25a0"; // block
            const string fb = "\u2588"; // left half block
            //const string lh = "\u258c"; // left half block
            //const string rh = "\u2590"; // right half block

            string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            // Draw the top board boundary 
            Write ( "   " );
            for( int p = 0; p < board.GetLength( 1 ); p++ )
            {
                Write ("  {0} ", letters [ p ] );
            }

            WriteLine( );
            
            Write ( "   " );
            
            for ( int c = 0; c < board.GetLength( 1 ); c ++ )
            {
                if ( c == 0 ) Write( tl );
                Write( "{0}{0}{0}", h );
                if ( c == board.GetLength( 1 ) - 1 ) Write( "{0}", tr );
                else                                 Write( "{0}", hb );
            }
            
            WriteLine( );

            // Draw the board rows.
            for ( int r = 0; r < board.GetLength( 0 ); r++ )
            {
                Write( " {0} ", letters[ r ] );

                // Draw the row contents.
                for ( int c = 0; c < board.GetLength( 1 ); c++ )
                {
                    if ( c == 0 ) Write( v );

                    if ( board[ r, c ] )
                    {
                      if ( r == pawnRowA && c == pawnColumnA) Write( " A " + v );
                      else if ( r == pawnRowB && c == pawnColumnB) Write( " B " + v );
                      else if ( r == platformRowA && c == platformColumnA) Write( " {0} {1}", bb, v );
                      else if ( r == platformRowB && c == platformColumnB) Write( " {0} {1}", bb, v );
                      else Write(" {0} {1}", fb, v);
                    }
                    
                    // removing the tile
                    else if ( board [ checkIfRemovableRowA , checkIfRemovableColumnA ] == false )
                    {
                        Write( "   " + v );
                    }
                    
                    else if ( board [ checkIfRemovableRowB , checkIfRemovableColumnA ] == false )
                    {
                        Write( "   " + v );
                    }
                }
                
                WriteLine( );

                // Draw the boundary after the row.
                if ( r != board.GetLength( 0 ) - 1 )
                {
                    Write( "   " );
                    for ( int c = 0; c < board.GetLength( 1 ); c++ )
                    {
                        if ( c == 0 ) Write( vr ); 
                        Write( "{0}{0}{0}", h );
                        if ( c == board.GetLength( 1 ) - 1 ) Write( "{0}", vl );
                        else                                 Write( "{0}", hv );
                    }
                    
                    WriteLine ( );
                }
                
                else
                {
                    Write( "   " );
                    
                    for ( int c = 0; c < board.GetLength( 1 ); c ++ )
                    {
                        if ( c == 0 ) Write( bl );
                        Write( "{0}{0}{0}", h );
                        if ( c == board.GetLength( 1 ) - 1 ) Write( "{0}", br );
                        else                                 Write( "{0}", ha );
                    } 
                    WriteLine( );
                }
            }
        }
    }
}
