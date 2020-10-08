// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2738/judge/4898397/C++14
// est: 3min
// real: 3min
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n;
  cin >> n;
  int st = 0;
  for (int i = 0; i < n; i++){
    string s;
    cin >> s;
    if (s == "A") st++;
    else {
      st--;
      if (st < 0) goto no;
    }
  }
  if (st != 0) goto no;
  cout << "YES" << endl;
  return 0;
 no:;
  cout << "NO" << endl;
  return 0;
}

