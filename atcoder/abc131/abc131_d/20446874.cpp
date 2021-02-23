// detail: https://atcoder.jp/contests/abc131/submissions/20446874
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  using P = pair<int, int>;
  vector<P> p(n);
  for (int i = 0; i < n; i++) cin >> p[i].second >> p[i].first;
  sort(p.begin(), p.end());
  ll cur = 0;
  for (var&& elem : p) {
    var b = elem.first;
    var a = elem.second;
    cur += a;
    if (b < cur) {
      cout << "No" << endl;
      return 0;
    }
  }
  cout << "Yes" << endl;
}
