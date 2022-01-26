\ *
\ * Game of Life variables
\ *


\ ** variables for the field **
variable field-width
128 field-width ! \ <= 128 to allow largest possible field (otherwise memory leak into neighbouring areas)

: get-field-width field-width @ ;
: set-field-width field-width ! ;


variable field-height
get-field-width 2 / field-height !

: get-field-height field-height @ ;
: set-field-height field-height ! ;


variable field-size 
get-field-width get-field-height * field-size !

: get-field-size field-size @ ;
: set-field-size get-field-width get-field-height * field-size ! ;


\ ** variables for the world **
variable world-width
get-field-width 2 + world-width !

: get-world-width world-width @ ;
: set-world-width get-field-width 2 + world-width ! ;


variable world-height
get-field-height 2 + world-height !

: get-world-height world-height @ ;
: set-world-height get-field-height 2 + world-height ! ;

variable world-size 
get-world-width get-world-height * world-size !

: get-world-size world-size @ ;
: set-world-size get-world-width get-world-height * world-size ! ;


\ ** variables for evolution & life **
variable evolving-speed
1000 evolving-speed !

: get-evolving-speed evolving-speed @ ;
: set-evolving-speed evolving-speed ! ;


variable generation
0 generation !

: get-generation generation @ ;
: set-generation generation ! ;


variable counter-alive
0 counter-alive !

: get-counter-alive counter-alive @ ;
: set-counter-alive counter-alive ! ;


\ ** variables for the backup & restoring functions **
variable backup-created
false backup-created !

: get-backup-created backup-created @ ;
: set-backup-created backup-created ! ;


variable backup-evolving-speed
1000 backup-evolving-speed !

: get-backup-evolving-speed backup-evolving-speed @ ;
: set-backup-evolving-speed backup-evolving-speed ! ;


variable backup-generation
0 backup-generation !

: get-backup-generation backup-generation @ ;
: set-backup-generation backup-generation ! ;


variable backup-world-width

: get-backup-world-width backup-world-width @ ;
: set-backup-world-width backup-world-width ! ;


variable backup-world-size 

: get-backup-world-size backup-world-size @ ;
: set-backup-world-size backup-world-size ! ;