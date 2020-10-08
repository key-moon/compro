// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1124/judge/4898319/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

bool solve(){
  int n, q;
  cin >> n >> q;
  if (n == 0) return false;
  vector<int> ps(1000, 0);
  for (int i = 0; i < n; i++){
    int m; cin >> m;
    for (int j = 0; j < m; j++){
      int day; cin >> day;
      ps[day] += 1;
    }
  }
  int res = -1;
  int mx = -1;
  for (int i = 0; i < 1000; i++){
    if (ps[i] <= mx) continue;
    mx = ps[i];
    res = i;
  }
  if (mx < q) res = 0;
  cout << res << endl;
  return true;
}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  while(solve());
  return 0;
}

