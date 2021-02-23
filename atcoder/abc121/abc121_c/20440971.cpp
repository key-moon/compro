// detail: https://atcoder.jp/contests/abc121/submissions/20440971
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n, m;
  cin >> n >> m;
  using P = pair<int, int>;
  vector<P> vs(n);
  for (int i = 0; i < n; i++) {
    cin >> vs[i].first >> vs[i].second;
  }
  sort(vs.begin(), vs.end());
  ll res = 0;
  for (var&& item : vs) {
    ll d = min(m, item.second);
    res += item.first * d;
    m -= d;
  }
  cout << res << endl;
}
