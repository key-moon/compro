// detail: https://atcoder.jp/contests/abc128/submissions/20438382
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
  using P = pair<string, int>;
  using PP = pair<P, int>;
  vector<PP> ps{};
  for (int i = 0; i < n; i++) {
    string s; int p;
    cin >> s >> p;
    ps.emplace_back(P(s, -p), i + 1);
  }
  sort(ps.begin(), ps.end());
  for (var&& item : ps) {
    cout << item.second << endl;
  }
}
