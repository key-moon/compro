// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2881/judge/4923820/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  string s;
  int y, m, d;
  cin >> s;
  if (s == "#") return 0;
  cin >> y >> m >> d;
  if (32 <= y || (y == 31 && 5 <= m)){
    cout << "? " << (y - 30);
  }
  else{
    cout << s << " " << y;
  }
  cout << " " << m << " " << d << endl;
  main();
}

