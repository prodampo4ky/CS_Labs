#!/bin/bash

ml icc
echo "g++ with O"
g++ -O pr.cpp -o testO
time ./testO
echo " "
echo "g++ with O1"
g++ -O1 pr.cpp -o test1
time ./test1
echo " "
echo "g++ with O2"
g++ -O2 pr.cpp -o test2
time ./test2
echo " "
echo "g++ with O3"
g++ -O3 pr.cpp -o test3
time ./test3
echo " "
echo "g++ with O fast"
g++ -Ofast pr.cpp -o testFast
time ./testFast
echo " "
grep 'flags' /proc/cpuinfo | uniq
echo " "
echo -e "Extentions:\n"
echo "sse2"
icc -std=c++11 -xsse2 -O2 pr.cpp -o ntest
time ./n1test
echo " "
echo "ssse3"
icc -std=c++11 -xssse3 -O2 pr.cpp -o ntest
time ./n2test
echo " "
echo "avx"
icc -std=c++11 -xavx -O2 pr.cpp -o ntest
time ./n3test
echo " "