// detail: https://atcoder.jp/contests/arc073/submissions/20443060
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, t;
  cin >> n >> t;
  using P = pair<int, int>;
  vector<P> events{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    events.emplace_back(a, 1);
    events.emplace_back(a + t, -1);
  }
  sort(events.begin(), events.end());

  ll res = 0;
  ll prev = 0;
  ll cur = 0;
  for (var&& item : events) {
    var t = item.first;
    var d = item.second;
    if (cur == 0) {
      prev = t;
    }
    cur += d;
    if (cur == 0) {
      res += t - prev;
    }
  }
  cout << res << endl;
}
