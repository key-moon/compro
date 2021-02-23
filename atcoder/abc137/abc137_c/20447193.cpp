// detail: https://atcoder.jp/contests/abc137/submissions/20447193
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
  ll res = 0;
  map<string, int> cnts{};
  for (int i = 0; i < n; i++) {
    string s;
    cin >> s;
    sort(s.begin(), s.end());
    res += cnts[s];
    cnts[s]++;
  }
  cout << res << endl;
}
