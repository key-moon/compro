// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2739/judge/5238507/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m, t;
  cin >> n >> m >> t;
  using P = pair<int, int>;
  vector<P> events{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    events.emplace_back(a - m, 1);
    events.emplace_back(a + m, -1);
  }
  int res = 0;
  int prevPos = 0;
  int cur = 0;
  events.emplace_back(t, 1);
  sort(events.begin(), events.end());
  for (var&& event : events) {
    var pos = event.first;
    var d = event.second;
    if (cur == 0) res += pos - prevPos;
    cur += d;
    prevPos = pos;
  }
  cout << res << endl;
}

