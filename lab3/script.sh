#!/bin/bash

ml icc
echo "g++ with O"
g++ -O lab3.cpp -o test0
time ./test0
echo " "
echo "g++ with O1"
g++ -O1 lab3.cpp -o test1
time ./test1
echo " "
echo "g++ with O2"
g++ -O2 lab3.cpp -o test2
time ./test2
echo " "
echo "g++ with O3"
g++ -O3 lab3.cpp -o test3
time ./test3
echo " "
echo "g++ with O fast"
g++ -Ofast lab3.cpp -o testFast
time ./testFast
echo " "
grep 'flags' /proc/cpuinfo | uniq
echo " "
echo -e "Extentions:\n"
echo "sse2"
icc -std=c++11 -xsse2 -O2 lab3.cpp -o n1test
time ./n1test
echo " "
echo "ssse3"
icc -std=c++11 -xssse3 -O2 lab3.cpp -o n2test
time ./n2test
echo " "
echo "avx"
icc -std=c++11 -xavx -O2 lab3.cpp -o n3test
time ./n3test
echo " "