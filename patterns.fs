\ *
\ * Game of Life predefined patterns
\ *

\ pattern menu
: patterns ( -- )
cr cr
." [P] **--**--**--**-- PATTERNS --**--**--**--** " cr cr

." [P] **--**--** STILL LIFES **--**--**  " cr cr

." [P] BEEHIVE: " cr
." [P] ...... " cr
." [P] ..@@.. " cr
." [P] .@..@. " cr
." [P] ..@@.. " cr 
." [P] ...... " cr cr

." [P] **--**--** OSCILLATORS **--**--**  " cr cr

." [P] BLINKER: " cr
." [P] ..... " cr
." [P] .@@@. " cr
." [P] ..... " cr cr

." [P] TOAD: " cr
." [P] ...... " cr
." [P] ..@@@. " cr
." [P] .@@@.. " cr
." [P] ...... " cr cr

." [P] BEACON: " cr
." [P] ...... " cr
." [P] .@@... " cr
." [P] .@.... " cr
." [P] ....@. " cr
." [P] ...@@. " cr
." [P] ...... " cr cr

." [P] PULSAR (4x): " cr
." [P] ...@@@.. " cr
." [P] ........ " cr
." [P] .@....@. " cr
." [P] .@....@. " cr
." [P] .@....@. " cr
." [P] ...@@@.. " cr cr

." [?] **--**--** SPACESHIPS **--**--**  " cr cr

." [P] GLIDER: " cr
." [P] ..... " cr
." [P] ..@.. " cr
." [P] ...@. " cr
." [P] .@@@. " cr
." [P] ..... " cr cr

." [P] LWSS (Light weigth space ship): " cr
." [P] ....... " cr
." [P] .@..@.. " cr
." [P] .....@. " cr
." [P] .@...@. " cr
." [P] ..@@@@. " cr
." [P] ....... " cr cr

." [?] **--**--** METHUSELAHS **--**--**  " cr cr

." [P] R-PENTOMINO: " cr
." [P] ....... " cr
." [P] ...@@.. " cr
." [P] ..@@... " cr
." [P] ...@... " cr 
." [P] ....... " cr cr

." [P] DIEHARD: " cr
." [P] .......... " cr
." [P] .......@.. " cr
." [P] .@@....... " cr
." [P] ..@...@@@." cr 
." [P] .......... " cr cr

." [P] THUNDERBIRD: " cr
." [P] ..... " cr
." [P] .@@@. " cr
." [P] ..... " cr
." [P] ..@.. " cr 
." [P] ..@.. " cr 
." [P] ..@.. " cr
." [P] ..... " cr cr

." [P] UNKNOWN: " cr
." [P] ..... " cr
." [P] .@@@. " cr
." [P] .@.@. " cr
." [P] .@.@. " cr 
." [P] ..... " cr 
." [P] .@.@. " cr
." [P] .@.@. " cr 
." [P] .@@@. " cr
." [P] ..... " cr cr ;


\ deferred words
Defer df-silent-alive ( -- )
Defer df-print-world ( -- )
Defer df-fill-world-with-border ( -- )
Defer df-life ( -- )


\ pattern creation helpers
: x+ ( x y -- x+1 y) 
swap 1 + swap ;

: x- ( x y -- x-1 y) 
swap 1 - swap ;

: y+ ( x y -- x y+1) 
1 + ;

: y- ( x y -- x y-1) 
1 - ;


\ create most used base patterns

\ pat-two-in-a-row
: p2r { x y -- }
    x y df-silent-alive
    x 1+ y df-silent-alive ;

\ pat-three-in-a-row
: p3r { x y -- }
    x y df-silent-alive
    x 1 + y df-silent-alive
    x 2 + y df-silent-alive ;

\ pat-three-in-a-column
: p3c { x y -- }
    x y df-silent-alive
    x y 1 + df-silent-alive
    x y 2 + df-silent-alive ;

\ pat-three-in-a-diagonal (left top to right bottom)
: p3dlr { x y -- }
    x y df-silent-alive
    x 1 + y 1 + df-silent-alive
    x 2 + y 2 + df-silent-alive ;

\ pat-three-in-a-diagonal (right top to left bottom)
: p3drl { x y -- }
    x y df-silent-alive
    x 1 - y 1 + df-silent-alive
    x 2 - y 2 + df-silent-alive ;

\ pat-four-in-a-row
: p4r { x y -- }
    x y df-silent-alive
    x 1 + y df-silent-alive
    x 2 + y df-silent-alive 
    x 3 + y df-silent-alive ;

\ pat-four-in-a-column
: p4c { x y -- }
    x y df-silent-alive
    x y 1 + df-silent-alive
    x y 2 + df-silent-alive 
    x y 3 + df-silent-alive ;

\ pat-five-in-a-row
: p5r { x y -- }
    x y df-silent-alive
    x 1 + y df-silent-alive
    x 2 + y df-silent-alive 
    x 3 + y df-silent-alive
    x 4 + y df-silent-alive ;

\ pat-five-in-a-column
: p5c { x y -- }
    x y df-silent-alive
    x y 1 + df-silent-alive
    x y 2 + df-silent-alive 
    x y 3 + df-silent-alive
    x y 4 + df-silent-alive ;

\ pat-six-in-a-row
: p6r { x y -- }
    x y df-silent-alive
    x 1 + y df-silent-alive
    x 2 + y df-silent-alive 
    x 3 + y df-silent-alive
    x 4 + y df-silent-alive
    x 5 + y df-silent-alive ;

\ pat-six-in-a-column
: p6c { x y -- }
    x y df-silent-alive
    x y 1 + df-silent-alive
    x y 2 + df-silent-alive 
    x y 3 + df-silent-alive
    x y 4 + df-silent-alive 
    x y 5 + df-silent-alive ;

: pat_forth { x y -- }
    \ F
    x y p4r
    x y p4c
    x 4 + y p3r
    x 1 + y 4 + p4r
    x y 4 + p4c 
    
    \ O
    x 9 + y 2 + p4r
    x 9 + y 7 + p4r
    x 8 + y 3 + p4c
    x 13 + y 3 + p4c

    \ R
    x 15 + y 2 + p5r
    x 15 + y 3 + p5c
    x 20 + y 3 + df-silent-alive
    x 20 + y 4 + df-silent-alive
    x 15 + y 5 + p5r
    x 19 + y 6 + df-silent-alive
    x 20 + y 7 + df-silent-alive

    \ T
    x 22 + y 2 + p5r
    x 24 + y 3 + p5c

    \ H
    x 28 + y 2 + p6c
    x 33 + y 2 + p6c
    x 28 + y 4 + p6r ;

: pat_is { x y -- }
    \ I
    x y p6c

    \ S
    x 3 + y p4r
    x 3 + y 2 + p4r
    x 3 + y 5 + p4r
    x 2 + y 1 + df-silent-alive
    x 2 + y 4 + df-silent-alive
    x 7 + y 4 + df-silent-alive
    x 7 + y 3 + df-silent-alive ;

: pat_awesome { x y -- }

    \ A
    x y p2r
    x y p3drl
    x 1 + y p3dlr
    x 2 - y 2 + p4c
    x 2 - y 3 + p6r
    x 3 + y 2 + p4c 

    \ W
    x 5 + y p6c
    x 10 + y p6c
    x 7 + y 3 + p3drl
    x 8 + y 3 + p3dlr 

    \ E
    x 12 + y p6r
    x 12 + y p6c
    x 12 + y 2 + p5r
    x 12 + y 5 + p6r 

    \ S
    x 20 + y p4r
    x 20 + y 2 + p4r
    x 20 + y 5 + p4r
    x 19 + y 1 + df-silent-alive
    x 19 + y 4 + df-silent-alive
    x 24 + y 4 + df-silent-alive
    x 24 + y 3 + df-silent-alive

    \ O
    x 27 + y p4r
    x 27 + y 5 + p4r
    x 26 + y 1 + p4c
    x 31 + y 1 + p4c 

    \ M
    x 33 + y p6c
    x 33 + y p3dlr
    x 38 + y p3drl
    x 38 + y p6c

    \ E
    x 40 + y p6r
    x 40 + y p6c
    x 40 + y 2 + p5r
    x 40 + y 5 + p6r ;

: forth_is_awesome ( -- )
    16 6 pat_forth
    29 15 pat_is 
    11 22 pat_awesome ;
    
\ still lifes
: beehive ( x y -- )
    2dup df-silent-alive
    2dup x+ y- p2r 
    2dup x+ y+ p2r 
    swap 3 + swap df-silent-alive 
    page
    df-print-world ;


\ oscillators
: blinker ( x y -- )
    p3r
    page
    df-print-world ;

: toad ( x y -- )
    2dup
    p3r
    y- x+ 
    p3r
    page 
    df-print-world ;

: beacon ( x y -- )
    2dup
    p2r
    y+ 2dup
    p2r
    y+ swap 2 + swap
    2dup
    p2r
    y+ p2r 
    page
    df-print-world ;

: pulsar { x y -- }
    x 4 - y 6 - p3r
    x 2 + y 6 - p3r
    x 6 - y 4 - p3c
    x 1 - y 4 - p3c
    x 1 + y 4 - p3c
    x 6 + y 4 - p3c
    x 4 - y 1 - p3r
    x 2 + y 1 - p3r

    x 4 - y 1 + p3r
    x 2 + y 1 + p3r
    x 1 - y 2 + p3c
    x 6 - y 2 + p3c
    x 1 + y 2 + p3c
    x 6 + y 2 + p3c
    x 4 - y 6 + p3r
    x 2 + y 6 + p3r 
    page
    df-print-world ;


\ spaceships
: glider ( x y -- )
    2dup
    p3r
    1 - >r 2 + r> 2dup df-silent-alive
    y- x- df-silent-alive
    page
    df-print-world ;

: lwss { x y -- }
    x y df-silent-alive
    x 3 + y df-silent-alive
    x 4 + y 1 + p3c
    x y 2 + df-silent-alive
    x 1 + y 3 + p3r 
    page
    df-print-world ;


\ methuselahs
: r-petonimo ( x y -- )
    2dup 2dup
    p3c
    x+ df-silent-alive
    y+ x- df-silent-alive 
    page
    df-print-world ;

: diehard { x y -- }
    x y df-silent-alive
    x 1 + y df-silent-alive
    x 1 + y 1 + df-silent-alive
    x 5 + y 1 + p3r
    x 6 + y 1 - df-silent-alive 
    page
    df-print-world ; 

: thunderbird ( x y -- )
    2dup
    p3r
    2 + x+ p3c 
    page
    df-print-world ; 


\ unknown source?
: unknown { x y -- }
    x y p3c
    x y p3r
    x 2 + y p3c
    x y 4 + p3c
    x 2 + y 4 + p3c
    x y 6 + p3r
    page
    df-print-world ;


\ other
: silent-glider ( x y -- )
    2dup
    p3r
    1 - >r 2 + r> 2dup df-silent-alive
    y- x- df-silent-alive ;

: show-wrap ( -- )
    56 4 silent-glider
    56 16 silent-glider
    56 26 silent-glider
    32 28 silent-glider
    8 28 silent-glider 
    page
    df-print-world ;

: surprise ( -- )
    page
    df-print-world
    1000 ms
    16 6 pat_forth
    df-print-world
    1000 ms
    df-fill-world-with-border
    df-print-world
    29 15 pat_is
    df-print-world
    1000 ms
    df-fill-world-with-border
    df-print-world
    11 22 pat_awesome
    df-print-world
    1000 ms
    df-fill-world-with-border
    df-print-world

    16 6 pat_forth
    df-print-world
    500 ms
    df-fill-world-with-border
    df-print-world
    29 15 pat_is
    df-print-world
    500 ms
    df-fill-world-with-border
    df-print-world
    11 22 pat_awesome
    df-print-world
    500 ms
    df-fill-world-with-border
    df-print-world

    16 6 pat_forth
    df-print-world
    300 ms
    df-fill-world-with-border
    df-print-world
    29 15 pat_is
    df-print-world
    300 ms
    df-fill-world-with-border
    df-print-world
    11 22 pat_awesome
    df-print-world
    300 ms
    df-fill-world-with-border
    df-print-world

    16 6 pat_forth
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world
    29 15 pat_is
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world
    11 22 pat_awesome
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world

    forth_is_awesome
    df-print-world
    200 ms
    df-fill-world-with-border
    df-print-world
    forth_is_awesome
    df-print-world
    200 ms
    df-fill-world-with-border
    df-print-world
    forth_is_awesome
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world
    forth_is_awesome
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world
    forth_is_awesome
    df-print-world
    100 ms
    df-fill-world-with-border
    df-print-world

    forth_is_awesome
    200 set-evolving-speed
    df-life ;
