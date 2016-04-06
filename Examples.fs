module BrainFark.Examples

// https://esolangs.org/wiki/Brainfuck
let HelloWorldComplex =
    """
    >++++++++[-<+++++++++>]<.>>+>-[+]++>++>+++[>[->+++<<+++>]<<]>-----.>->
    +++..+++.>-.<<+[>[+>+]>>]<--------------.>>.+++.------.--------.>+.>+.
    """

// https://esolangs.org/wiki/Brainfuck
let HelloWorldShort = "--<-<<+[+[<+>--->->->-<<<]>]<<--.<++++++.<<-..<<.<+.>>.>>.<<<.+++.>>.>>-.<<<+."

// https://en.wikipedia.org/wiki/Brainfuck
let HelloWorld =
    """
    [ This program prints "Hello World!" and a newline to the screen, its
      length is 106 active command characters. [It is not the shortest.]

      This loop is a "comment loop", a simple way of adding a comment
      to a BF program such that you don't have to worry about any command
      characters. Any ".", ",", "+", "-", "<" and ">" characters are simply
      ignored, the "[" and "]" characters just have to be balanced. This
      loop and the commands it contains are ignored because the current cell
      defaults to a value of 0; the 0 value causes this loop to be skipped.
    ]
    +++++ +++               Set Cell #0 to 8
    [
        >++++               Add 4 to Cell #1; this will always set Cell #1 to 4
        [                   as the cell will be cleared by the loop
            >++             Add 2 to Cell #2
            >+++            Add 3 to Cell #3
            >+++            Add 3 to Cell #4
            >+              Add 1 to Cell #5
            <<<<-           Decrement the loop counter in Cell #1
        ]                   Loop till Cell #1 is zero; number of iterations is 4
        >+                  Add 1 to Cell #2
        >+                  Add 1 to Cell #3
        >-                  Subtract 1 from Cell #4
        >>+                 Add 1 to Cell #6
        [<]                 Move back to the first zero cell you find; this will
                            be Cell #1 which was cleared by the previous loop
        <-                  Decrement the loop Counter in Cell #0
    ]                       Loop till Cell #0 is zero; number of iterations is 8

    The result of this is:
    Cell No :   0   1   2   3   4   5   6
    Contents:   0   0  72 104  88  32   8
    Pointer :   ^

    >>.                     Cell #2 has value 72 which is 'H'
    >---.                   Subtract 3 from Cell #3 to get 101 which is 'e'
    +++++++..+++.           Likewise for 'llo' from Cell #3
    >>.                     Cell #5 is 32 for the space
    <-.                     Subtract 1 from Cell #4 for 87 to give a 'W'
    <.                      Cell #3 was set to 'o' from the end of 'Hello'
    +++.------.--------.    Cell #3 for 'rl' and 'd'
    >>+.                    Add 1 to Cell #5 gives us an exclamation point
    >++.                    And finally a newline from Cell #6
    """

// https://en.wikipedia.org/wiki/Brainfuck
let ROT13 =
    """
    -,+[                         Read first character and start outer character reading loop
        -[                       Skip forward if character is 0
            >>++++[>++++++++<-]  Set up divisor (32) for division loop
                                   (MEMORY LAYOUT: dividend copy remainder divisor quotient zero zero)
            <+<-[                Set up dividend (x minus 1) and enter division loop
                >+>+>-[>>>]      Increase copy and remainder / reduce divisor / Normal case: skip forward
                <[[>+<-]>>+>]    Special case: move remainder back to divisor and increase quotient
                <<<<<-           Decrement dividend
            ]                    End division loop
        ]>>>[-]+                 End skip loop; zero former divisor and reuse space for a flag
        >--[-[<->+++[-]]]<[         Zero that flag unless quotient was 2 or 3; zero quotient; check flag
            ++++++++++++<[       If flag then set up divisor (13) for second division loop
                                   (MEMORY LAYOUT: zero copy dividend divisor remainder quotient zero zero)
                >-[>+>>]         Reduce divisor; Normal case: increase remainder
                >[+[<+>-]>+>>]   Special case: increase remainder / move it back to divisor / increase quotient
                <<<<<-           Decrease dividend
            ]                    End division loop
            >>[<+>-]             Add remainder back to divisor to get a useful 13
            >[                   Skip forward if quotient was 0
                -[               Decrement quotient and skip forward if quotient was 1
                    -<<[-]>>     Zero quotient and divisor if quotient was 2
                ]<<[<<->>-]>>    Zero divisor and subtract 13 from copy if quotient was 1
            ]<<[<<+>>-]          Zero divisor and add 13 to copy if quotient was 0
        ]                        End outer skip loop (jump to here if ((character minus 1)/32) was not 2 or 3)
        <[-]                     Clear remainder from first division if second division was skipped
        <.[-]                    Output ROT13ed character from copy and clear it
        <-,+                     Read next character
    ]                            End character reading loop
    """
    
// http://www.99-bottles-of-beer.net/language-brainfuck-101.html
let NintyNineBottles =
    """
    ##########################
    ###
    ### Severely updated version!
    ### (now says "1 bottle" and
    ### contains no extra "0" verse)
    ###
    ##########################
    ### 99 Bottles of Beer ###
    ### coded in Brainfuck ###
    ### with explanations  ###
    ##########################
    #
    # This Bottles of Beer program
    # was written by Andrew Paczkowski
    # Coder Alias: thepacz
    # three_halves_plus_one@yahoo.com
    #####

    >                            0 in the zeroth cell
    +++++++>++++++++++[<+++++>-] 57 in the first cell or "9"
    +++++++>++++++++++[<+++++>-] 57 in second cell or "9"
    ++++++++++                   10 in third cell
    >+++++++++                    9 in fourth cell

    ##########################################
    ### create ASCII chars in higher cells ###
    ##########################################

    >>++++++++[<++++>-]               " "
    >++++++++++++++[<+++++++>-]        b
    +>+++++++++++[<++++++++++>-]       o
    ++>+++++++++++++++++++[<++++++>-]  t
    ++>+++++++++++++++++++[<++++++>-]  t
    >++++++++++++[<+++++++++>-]        l
    +>++++++++++[<++++++++++>-]        e
    +>+++++++++++++++++++[<++++++>-]   s
    >++++++++[<++++>-]                " "
    +>+++++++++++[<++++++++++>-]       o
    ++>++++++++++[<++++++++++>-]       f
    >++++++++[<++++>-]                " "
    >++++++++++++++[<+++++++>-]        b
    +>++++++++++[<++++++++++>-]        e
    +>++++++++++[<++++++++++>-]        e
    >+++++++++++++++++++[<++++++>-]    r
    >++++++++[<++++>-]                " "
    +>+++++++++++[<++++++++++>-]       o
    >+++++++++++[<++++++++++>-]        n
    >++++++++[<++++>-]                " "
    ++>+++++++++++++++++++[<++++++>-]  t
    ++++>++++++++++[<++++++++++>-]     h
    +>++++++++++[<++++++++++>-]        e
    >++++++++[<++++>-]                " "
    ++>+++++++++++++[<+++++++++>-]     w
    +>++++++++++++[<++++++++>-]        a
    >++++++++++++[<+++++++++>-]        l
    >++++++++++++[<+++++++++>-]        l
    >+++++[<++>-]                      LF
    ++>+++++++++++++++++++[<++++++>-]  t
    +>++++++++++++[<++++++++>-]        a
    +++>+++++++++++++[<++++++++>-]     k
    +>++++++++++[<++++++++++>-]        e
    >++++++++[<++++>-]                " "
    +>+++++++++++[<++++++++++>-]       o
    >+++++++++++[<++++++++++>-]        n
    +>++++++++++[<++++++++++>-]        e
    >++++++++[<++++>-]                " "
    >++++++++++[<++++++++++>-]         d
    +>+++++++++++[<++++++++++>-]       o
    ++>+++++++++++++[<+++++++++>-]     w
    >+++++++++++[<++++++++++>-]        n
    >++++++++[<++++>-]                " "
    +>++++++++++++[<++++++++>-]        a
    >+++++++++++[<++++++++++>-]        n
    >++++++++++[<++++++++++>-]         d
    >++++++++[<++++>-]                " "
    ++>+++++++++++[<++++++++++>-]      p
    +>++++++++++++[<++++++++>-]        a
    +>+++++++++++++++++++[<++++++>-]   s
    +>+++++++++++++++++++[<++++++>-]   s
    >++++++++[<++++>-]                " "
    +>+++++++++++++[<++++++++>-]       i
    ++>+++++++++++++++++++[<++++++>-]  t
    >++++++++[<++++>-]                " "
    +>++++++++++++[<++++++++>-]        a
    >+++++++++++++++++++[<++++++>-]    r
    +>+++++++++++[<++++++++++>-]       o
    >+++++++++++++[<+++++++++>-]       u
    >+++++++++++[<++++++++++>-]        n
    >++++++++++[<++++++++++>-]         d
    >+++++[<++>-]                      LF
    +++++++++++++                      CR

    [<]>>>>      go back to fourth cell

    #################################
    ### initiate the display loop ###
    #################################

    [            loop
     <           back to cell 3
     [            loop
      [>]<<       go to last cell and back to LF
      ..          output 2 newlines
      [<]>        go to first cell

     ###################################
     #### begin display of characters###
     ###################################
     #
     #.>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     #X X     b o t t l e s   o f   b e e r  
     #.>.>.>.>.>.>.>.>.>.>.>.
     #o n   t h e   w a l l N
     #[<]>    go to first cell
     #.>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>>>>>>>>>>>>>.>
     #X X     b o t t l e s   o f   b e e r             N
     #.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     #t a k e   o n e   d o w n   a n d   p a s s   
     #.>.>.>.>.>.>.>.>.>.
     #i t   a r o u n d N
     #####

      [<]>>      go to cell 2
      -          subtract 1 from cell 2
      <          go to cell 1

     ########################
     ### display last line ##
     ########################
     #
     #.>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     #X X     b o t t l e s   o f   b e e r  
     #.>.>.>.>.>.>.>.>.>.>.
     #o n   t h e   w a l l
     #####

      [<]>>>-      go to cell 3/subtract 1
     ]            end loop when cell 3 is 0
     ++++++++++   add 10 to cell 3
     <++++++++++  back to cell 2/add 10
     <-           back to cell 1/subtract 1
     [>]<.        go to last line/carriage return
     [<]>         go to first line

    ########################
    ### correct last line ##
    ########################
    #
    #.>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
    #X X     b o t t l e s   o f   b e e r  
    #.>.>.>.>.>.>.>.>.>.>.
    #o n   t h e   w a l l
    #####

     [<]>>>>-    go to cell 4/subtract 1
    ]           end loop when cell 4 is 0

    ##############################################################
    ### By this point verses 99\10 are displayed but to work   ###
    ### with the lower numbered verses in a more readable way  ###
    ### we initiate a new loop for verses 9{CODE} that will not    ###
    ### use the fourth cell at all                             ###
    ##############################################################

    +           add 1 to cell four (to keep it non\zero)
    <--         back to cell 3/subtract 2

    [            loop
     [>]<<       go to last cell and back to LF
     ..          output 2 newlines
     [<]>        go to first cell

     ###################################
     #### begin display of characters###
     ###################################
     #
     #>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     # X     b o t t l e s   o f   b e e r  
     #.>.>.>.>.>.>.>.>.>.>.>.
     #o n   t h e   w a l l N
     #[<]>    go to first cell
     #>.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>>>>>>>>>>>>>.>
     # X     b o t t l e s   o f   b e e r             N
     #.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     #t a k e   o n e   d o w n   a n d   p a s s   
     #.>.>.>.>.>.>.>.>.>.
     #i t   a r o u n d N
     #####

     [<]>>       go to cell 2
     -           subtract 1 from cell 2

     ########################
     ### display last line ##
     ########################
     #
     #.>>>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
     #X     b o t t l e s   o f   b e e r  
     #.>.>.>.>.>.>.>.>.>.>.
     #o n   t h e   w a l l
     #####

     [<]>>>-     go to cell 3/subtract 1
    ]            end loop when cell 3 is 0
    +            add 1 to cell 3 to keep it non\zero

    [>]<.        go to last line/carriage return
    [<]>         go to first line

    ########################
    ### correct last line ##
    ########################
    #
    #>.>>>.>.>.>.>.>.>.>>.>.>.>.>.>.>.>.>.>
    # X     b o t t l e    o f   b e e r  
    #.>.>.>.>.>.>.>.>.>.>.<<<<.
    #o n   t h e   w a l l
    #####

    [>]<<       go to last cell and back to LF
    ..          output 2 newlines
    [<]>        go to first line

    #########################
    ### the final verse    ##
    #########################
    #
    #>.>>>.>.>.>.>.>.>.>>.>.>.>.>.>.>.>.>.>
    # X     b o t t l e    o f   b e e r  
    #.>.>.>.>.>.>.>.>.>.>.>.
    #o n   t h e   w a l l N
    #[<]>        go to first cell
    #>.>>>.>.>.>.>.>.>.>>.>.>.>.>.>.>.>.>>>>>>>>>>>>>.>
    # X     b o t t l e    o f   b e e r             N
    #.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
    #t a k e   o n e   d o w n   a n d   p a s s   
    #.>.>.>.>.>.>.>.>.>.
    #i t   a r o u n d N
    #[>]<        go to last line
    #<<<.<<.<<<.
    #   n  o    
    #[<]>>>>     go to fourth cell
    #>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>
    #   b o t t l e s   o f   b e e r  
    #.>.>.>.>.>.>.>.>.>.>.>.
    #o n   t h e   w a l l N
    #####fin##
    """

// http://esoteric.sange.fi/brainfuck/bf-source/prog/fibonacci.txt
let Factorial =
    """
    +++++++++++++++++++++++++++++++++			c1v33 : ASCII code of !
    >++++++++++++++++++++++++++++++
    +++++++++++++++++++++++++++++++				c2v61 : ASCII code of =
    >++++++++++						c3v10 : ASCII code of EOL
    >+++++++						c4v7  : quantity of numbers to be calculated
    >							c5v0  : current number (one digit)
    >+							c6v1  : current value of factorial (up to three digits)
    <<							c4    : loop counter
    [							block : loop to print one line and calculate next
    >++++++++++++++++++++++++++++++++++++++++++++++++.	c5    : print current number
    ------------------------------------------------	c5    : back from ASCII to number
    <<<<.-.>.<.+						c1    : print !_=_

    >>>>>							block : print c6 (preserve it)
    >							c7v0  : service zero
    >++++++++++						c8v10 : divizor
    <<							c6    : back to dividend
    [->+>-[>+>>]>[+[-<+>]>+>>]<<<<<<]			c6v0  : divmod algo borrowed from esolangs; results in 0 n d_n%d n%d n/d
    >[<+>-]							c6    : move dividend back to c6 and clear c7
    >[-]							c8v0  : clear c8

    >>							block : c10 can have two digits; divide it by ten again
    >++++++++++						c11v10: divizor
    <							c10   : back to dividend
    [->-[>+>>]>[+[-<+>]>+>>]<<<<<]				c10v0 : another divmod algo borrowed from esolangs; results in 0 d_n%d n%d n/d
    >[-]							c11v0 : clear c11
    >>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]c13v0 : print nonzero n/d (first digit) and clear c13
    <[++++++++++++++++++++++++++++++++++++++++++++++++.[-]] c12v0 : print nonzero n%d (second digit) and clear c12
    <<<++++++++++++++++++++++++++++++++++++++++++++++++.[-]	c9v0  : print any n%d (last digit) and clear c9

    <<<<<<.							c3    : EOL
    >>+							c5    : increment current number
							    block : multiply c6 by c5 (don't preserve c6)
    >[>>+<<-]						c6v0  : move c6 to c8
    >>							c8v0  : repeat c8 times
    [
    <<<[>+>+<<-]						c5v0  : move c5 to c6 and c7
    >>[<<+>>-]						c7v0  : move c7 back to c5
    >-
    ]
    <<<<-							c4    : decrement loop counter
    ]
    """
