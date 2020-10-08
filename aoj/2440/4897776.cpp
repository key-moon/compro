// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2440/judge/4897776/C++14
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
  set<string> s{};
  for (int i = 0; i < n; i++){
    string t;
    cin >> t;
    s.insert(t);
  }
  int state = 0;
  int m;
  cin >> m;
  for (int i = 0; i < m; i++){
    string t;
    cin >> t;
    string res;
    if (!s.count(t)) res = "Unknown";
    else {
      if (state) res = "Closed by";
      else res = "Opened by";
      state = !state;
    }
    cout << res << " " << t << endl;
  }
  return 0;
}

