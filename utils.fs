\ *
\ * Game of Life utilities
\ *

: banner ( -- )
page 
0 0 at-xy ."   ______                             ___    _       _  ___            "   
0 1 at-xy ."  / _____)                           / __)  | |     (_)/ __)           "  
0 2 at-xy ." | /  ___  ____ ____   ____     ___ | |__   | |      _| |__ ____       "
0 3 at-xy ." | | (___)/ _  |    \ / _  )   / _ \|  __)  | |     | |  __) _  )      "
0 4 at-xy ." | \____/( ( | | | | ( (/ /   | |_| | |     | |_____| | | ( (/ /       "
0 5 at-xy ."  \_____/ \_||_|_|_|_|\____)   \___/|_|     |_______)_|_|  \____)      " cr cr ;
                                                                                          

: help ( -- )
cr cr
." [?] **--**--**--**-- HELP MENU --**--**--**--** " cr cr

." [?] KEY: " cr
." [?] # ... border, @ ... cell is alive, . ... cell is dead, ? ... selector icon " cr cr

." [?] **--**--** COMMANDS **--**--**  " cr
." [?] help       ... print the help menu " cr 
." [?] patterns   ... print all preconfigured patterns (their names depict the cmd to use)" cr
." [->] e.g. for creating a glider use: x y glider" cr cr

." [?] WORLD OPERATIONS: " cr
." [?] print      ... print the world " cr
." [?] clear      ... clear world " cr
." [?] x resize   ... resize the world to width x " cr cr

." [?] EVOLUTION OPERATIONS: " cr
." [?] n speed    ... set evolving speed (default 1000 ms) " cr
." [?] evolve     ... evolve for 1 step " cr
." [?] life       ... start the evolution (end with [q]) " cr
." [?] n advance  ... advance evolution for n steps " cr cr

." [?] FIELD OPERATIONS: " cr
." [?] x y select ... check if cell is correct " cr
." [?] x y alive  ... switch cell state to alive " cr
." [?] x y dead   ... switch cell state to dead " cr cr

." [?] BACKUP OPERATIONS: " cr
." [?] backup         ... backup current parameters & world state " cr
." [?] restore        ... restore parameters & world state from backup " cr
." [?] print-backup   ... print backup" ; 


: ask-help ( x y -- ) 
    cr cr
    ." [?] Do you need help? [press ENTER to skip]"
    key 13 = invert if
        help
    else 
        cr
        ." [!] Have fun! Enter 'help' in case of trouble! "
    endif ;


Defer df-start

: (c) ( -- )
    ." Copyright " $A9 ( '©' ) xemit ;
: gforth ( -- ) cr
    ." Gforth " version-string type cr
    ." Authors: Anton Ertl, Bernd Paysan, Jens Wilke et al., for more type `authors'" cr
    (c) ."  2021 Free Software Foundation, Inc." cr
    ." License GPLv3+: GNU GPL version 3 or later <https://gnu.org/licenses/gpl.html>" cr
    ." Gforth comes with ABSOLUTELY NO WARRANTY; for details type `license'"
    df-start
;

' gforth IS bootmessage