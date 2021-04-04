#!/bin/bash

for p in 127.0.0.1,10000 127.0.0.1,10001 127.0.0.2,10000 127.0.0.2,10001 127.0.0.3,10000 127.0.0.3,10001;  do IFS=","; set -- $p;
    ./kvServer -a $1 -p "$2" > /dev/null &
done

ps aux | grep kvServer