# detail: https://atcoder.jp/contests/agc047/submissions/15836629
puts s=9394,
a=?+,0,1,m=9,?<,2,9,3,
[0,1].map{|p|[a,3,p,p]+(s=0..59).map{[a,u=p+4,u,u,a,3,u,6,[a,6,6,6]*(59-_1),?<,6,p,m+=1,a,u,m,u]}},
s.map{|_|[a,2,2,2]+(1.._).map{[a,40+_-_1,99+_1,5,?<,3,5,5,a,2,5,2]}}