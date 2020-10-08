// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1616/judge/4898273/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

bool solve(){
  int n, m;
  cin >> n >> m;
  if (n == 0) return false;
  vector<int> a(n);
  for (int i = 0; i < n; i++){
    cin >> a[i];
  }
  int mx = -1;
  for (int i = 0; i < n; i++){
    for (int j = i + 1; j < n; j++){
      var sum = a[i] + a[j];
      if (m < sum) continue;
      chmax(mx, sum);
    }
  }
  if (mx == -1) cout << "NONE" << endl;
  else cout << mx << endl;
  return true;
}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  while (solve());
  return 0;
}

