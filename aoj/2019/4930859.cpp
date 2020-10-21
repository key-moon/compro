// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2019/judge/4930859/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }


signed main() {
  ll n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  using P = pair<ll, ll>;
  vector<P> v{};
  for (int i = 0; i < n; i++){
    ll d, p;
    cin >> d >> p;
    v.emplace_back(d, p);
  }
  sort(v.begin(), v.end(), [](P a, P b){ return a.second > b.second; });
  ll res = 0;
  for (var&& item : v){
    var [d, p] = item;
    var rem = min(m, d);
    d -= rem;
    m -= rem;
    res += d * p;
  }
  cout << res << endl;
  main();
}

