// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2745/judge/4923817/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  int R, W, c, r;
  cin >> R >> W >> c >> r;
  if (R == 0) return 0;
  for (int i = 0; ; i++){
    var num = R + i * r;
    var add = num - W * c;
    if (add < 0) continue;
    cout << i << endl;
    break;
  }
  main();
}

