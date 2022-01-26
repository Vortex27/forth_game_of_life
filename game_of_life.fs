\ *
\ * Game of Life main program
\ *

require variables.fs
require patterns.fs
require utils.fs

: endif POSTPONE then ; immediate

\ retrieve user input for world width (-> size)
\ use default size 64 * 32 if input is invalid
: input-world-width ( n? -- )
	 cr ." [x] Please enter the width of the field to be generated "
     cr ." [!] Note: input has to be dividable by 2; max input 128 "
     cr ." [!] Note: press ENTER to use default width 64 "
     cr ." [?] Input: "
     pad 3 accept cr
     pad swap s>number?
     >r d>s r> over 128 <= AND over 0 > AND over 2 mod 0 = AND if 
        dup 2 / swap 2dup ." [x] The field size will be: " . ." x " . set-field-width set-field-height set-world-width set-world-height set-world-size
	 else 
        ." [!] You didn't enter a valid number! => Using default size 64 x 32 " drop ( dropping flag of checking if number has been entered )
        64 set-field-width 32 set-field-height set-world-width set-world-height set-world-size 
    endif ;


\ create worlds with specified size
create world get-world-size cells allot
create new-world get-world-size cells allot
create backup-world get-world-size cells allot


\ wrapping around if borders are crossed by user or cells
: wrap-around { x y -- x y }
    x get-field-width > if
        x get-field-width mod 0 = if 
            get-field-width
        else 
            x get-field-width mod
        endif
    else
        x 0 < if
            x get-field-width mod
        else
            x 0 = if
                get-field-width
            else
                x
            endif
        endif
    endif

    y get-field-height > if
        y get-field-height mod 0 = if
            get-field-height
        else
            y get-field-height mod
        endif
    else
        y 0 < if
            y get-field-height mod
        else 
            y 0 = if
                get-field-height
            else
                y
            endif
        endif
    endif ;


\ calculate the number of a specific field in the world array
: calculate-field-number { x y -- n }
    x y wrap-around 
    get-world-width * + ; 


\ fill the world array with content (border & field)
: fill-world-with-border ( -- )
    get-world-height 0 u+do
        get-world-width 0 u+do
            \ if 
            i 0 = j 0 = OR i get-world-width 1- = j get-world-height 1- = OR OR  if
                \ 35 = #
                35 world i j get-world-width * + cells + !
            else
                \ 32 = " " ; 46 = .
                46 world i j get-world-width * + cells + ! 
            endif
        loop
    loop ;


\ check if specific cell (at given x and y) is alive
: check-alive { x y -- 1/true 0/false }
    world x y calculate-field-number cells + @ 64 = if
    1 else 0 endif ;


\ count the neighbours of a specific cell (at given x and y) in a moore neighbourhood (8 cells around)
: count-neighbours ( x y -- n)
    0 >r
    2dup 2dup 1 + check-alive r> + >r \ north neighbour
    1 - check-alive r> + >r \ south neighbour
    over 1 + over 2dup check-alive r> + >r \ east neighbour
    2dup 1 - check-alive r> + >r \ northeast neighbour
    1 + check-alive r> + >r \ southeast neighbour 
    over 1 - over 2dup check-alive r> + >r \ west neighbour
    1 - check-alive r> + >r \ northwest neighbour
    1 + swap 1 - swap check-alive r> + ; \ southwest neighbour 


\ count currently living cells in the world
: count-alive ( -- )
    0 set-counter-alive
    get-world-height 0 u+do
        get-world-width 0 u+do
            world i j get-world-width * + cells + @ 64 = if
                1 counter-alive +!
            endif
        loop
    loop ;


\ universal print function; needs addr, world size (u) and world-width (n) of world to print
: print-any ( addr u n -- )
    0 0 at-xy
    { world-width }
    over -rot world-width + cr
    world-width u+do
        over 
        i cells + dup -rot swap ?do
            i @ emit
        [ 1 cells ] literal +loop
    cr 
    world-width +loop drop drop ;


: print-world ( -- )
    world get-world-size get-world-width print-any 
    ." Generation: " get-generation . cr ;


: print-new-world ( -- )
    new-world get-world-size get-world-width print-any ;


: print-backup ( -- )
    get-backup-created if
        page
        backup-world get-backup-world-size get-backup-world-width print-any 
        ." Generation: " get-backup-generation . cr
        ." [!] ATTENTION: You are viewing the backup version of the world, NOT the current one! " cr
    else 
        cr ." [!] No backup has been created yet! "
    endif ;


\ resize world to new width x
\ input validation & ask for confirmation
: resize ( x -- ) 
    cr
    ." [!] ATTENTION: Resizing the world will result in loosing the current simulation state! " cr
    ." [!] Are you sure you want to proceed? [y/n] "
    key 121 = if
        dup 128 <= over 0 > AND over 2 mod 0 = AND if 
            dup 2 /
            set-field-height
            set-field-width
            set-world-height
            set-world-width
            set-world-size
            here get-world-size cells allot
            world ! cr
            ." [x] The new field size will be: " get-field-width . ." x " get-field-height . 
            0 set-generation
            0 set-counter-alive
            fill-world-with-border
        else
            cr
            ." [!] You didn't enter a valid number! " cr 
            ." [!] World size remains unchanged. "
            drop
        endif
    else 
        cr
        ." [!] World size remains unchanged. "
        drop
    endif ;


\ clear content of world; empty field remains
\ ask for confirmation
: clear ( -- ) 
    cr
    ." [!] ATTENTION: Clearing the world will result in loosing the current simulation state! " cr
    ." [!] Are you sure you want to proceed? [y/n] "
    key 121 = if
        fill-world-with-border
        0 set-generation
        0 set-counter-alive
        page
        print-world
    else 
        cr
        ." [!] World remains unchanged. "
    endif ;


\ change evolution speed
: speed ( n -- )
    dup
    set-evolving-speed cr
    ." [x] Speed of evolution set to " . ." ms" ; 


\ print the selector icon '?' at a given field number
: print-field-selector { n -- }
    page
    n 0 u+do
        i 0 = invert i get-world-width mod 0 = and if
                cr
        endif
        world i cells + @ emit
    loop
        
    63 emit \ print an ?

    get-world-size n 1+ u+do
        i get-world-width mod 0 = if
                cr
        endif
        world i cells + @ emit
     loop
     cr ;


\ QoL cmd; print '?' at specified x and y
: select ( x y -- )
    calculate-field-number print-field-selector ;


\ QoL cmd; clear terminal & print world
: print 
    page
    print-world ;


\ change state of specific cell (in world) to alive -> @
: alive { n1 n2 -- }
    page 
    64 world n1 n2 calculate-field-number cells + !
    page
    print-world ;


\ change state of specific cell (in world) to dead -> .
: dead { n1 n2 -- } \ -> .
    page 
    46 world n1 n2 calculate-field-number cells + !
    page
    print-world ;


\ set specific cell (in world) to alive, without printing the world
\ primarily for usage in pattern creation
: silent-alive { n1 n2 -- } \ -> @
    64 world n1 n2 calculate-field-number cells + ! ;


\ change state of specific cell (in new world) to alive -> @
: alive-new-world { n1 n2 -- }
    64 new-world n1 n2 calculate-field-number cells + ! ;


\ change state of specific cell (in new world) to dead -> .
: dead-new-world { n1 n2 -- } \ -> -
    46 new-world n1 n2 calculate-field-number cells + ! ;


\ evolve world for 1 step
variable number-of-neighbours
: evolve ( -- )

world new-world get-world-size cell * move \ swap worlds

get-field-height 1+ 1 u+do
    get-field-width 1+ 1 u+do

            i j count-neighbours number-of-neighbours !

            i j check-alive 1 = if \ cell is alive
                number-of-neighbours @ 2 = number-of-neighbours @ 3 = OR if
                    i j alive-new-world
                else
                    i j dead-new-world
                endif
            else \ cell is dead
                number-of-neighbours @ 3 = if
                    i j alive-new-world
                endif
            endif
    loop
loop 
new-world world get-world-size cell * move \ swap worlds
1 generation +! ; 


\ backup world and its parameters
\ ask for confirmation if necessary
: backup ( -- ) 
    get-backup-created if
        cr ." [!] ATTENTION: There is already a backup!"
        cr ." [!] Are you sure you want to overwrite it? [y/n] "
        key 121 <> if
            cr ." [!] Backup aborted!"
            exit
        endif
    endif
    true set-backup-created
    get-evolving-speed set-backup-evolving-speed
    get-generation set-backup-generation 
    world backup-world get-world-size cell * move
    get-world-width set-backup-world-width
    get-world-size set-backup-world-size
    cr ." [B] World state & parameters saved!" ;


\ restore world & its parameters from backup
\ input validation & ask for confirmation
: restore ( -- ) 
get-backup-created if 
    cr ." [!] ATTENTION: Restoring the world state from backup will result in loosing the current simulation state! "
    cr ." [!] Are you sure you want to proceed? [y/n] "
    key 121 = if
        get-world-size get-backup-world-size <> if
            get-backup-world-width 2 - dup { backup-field-width }
            2 / set-field-height
            backup-field-width set-field-width
            set-world-height
            set-world-width
            set-world-size
            here get-world-size cells allot
            world ! cr
            fill-world-with-border
            ." [B] World resized to: " backup-field-width dup . ." x " 2 / .
        endif 
            get-backup-generation set-generation
            get-backup-evolving-speed set-evolving-speed
            backup-world world get-world-size cell * move cr
            ." [B] World state restored from backup!" cr
            ." [B] Parameters rolled back!" cr
    else 
        cr
        ." [!] Restoring aborted! World & parameters remain unchanged. "
    endif 
else
    cr
    ." [!] No backup has been created yet! " cr
endif ;


\ evolve world until key <q> is pressed
: life  ( -- ) 
    page
    begin
        evolve 
        print-world 
        get-evolving-speed ms
        count-alive
        ." [#]Living cells: " get-counter-alive dup . ." [#]Dead cells: " get-field-size - abs . cr 
        ." Running with speed: " get-evolving-speed . ." ms " cr
        ." End with [q] " cr
    key? if 
        key 113 = 
    else
        false
    endif 
    until ;

\ evolve world for a specifed amount of steps
\ input validation
: advance ( n -- )
    dup 0 <= if 
        cr
        ." [!] Please enter a number greater 0 to advance in evolution!" cr
        drop
    else 
        dup 0 u+do
            evolve
        loop
        page
        print-world 
        count-alive
        ." [#]Living cells: " get-counter-alive dup . ." [#]Dead cells: " get-field-size - abs . cr 
        ." [x] Advanced life for " . ." steps! " cr
    endif
;


\ start the game of life program
: start ( -- )
    page
    banner
    input-world-width
    fill-world-with-border 
    ask-help ;

\ set deferred words
' silent-alive IS df-silent-alive
' print-world IS df-print-world
' fill-world-with-border IS df-fill-world-with-border
' life IS df-life
' start IS df-start