# detail: https://atcoder.jp/contests/agc047/submissions/15837599
puts 9394,a=?+,0,1,m=9,?<,2,9,u=3,
[a,5-u+=1,3,9]+(0..59).map{[a,u,u,u,a,u,3,6,[a,6,6,6]*(59-_1),?<,6,9,m+=1,a,u,m,u]},
[a,5-u+=1,3,9]+(0..59).map{[a,u,u,u,a,u,3,6,[a,6,6,6]*(59-_1),?<,6,9,m+=1,a,u,m,u]},
(0..59).map{|m|[a,2,2,2]+(1..m).map{[a,40+m-_1,99+_1,u,?<,3,u,u,a,u,2,2]}}