// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1624/judge/4898353/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

bool solve(){
  int n;
  cin >> n;
  if (n == 0) return false;
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  ll avg = accumulate(a.begin(), a.end(), 0LL) / n;
  int res = count_if(a.begin(), a.end(), [&](int x){return x<=avg;});
  cout << res << endl;
  return res;
}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  while(solve());
  return 0;
}

