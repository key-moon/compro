// detail: https://atcoder.jp/contests/abc114/submissions/20436019
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int res = INT_MAX;
  for (int i = 0; i <= s.size() - 3; i++) {
    int val = (s[i] - '0') * 100 + (s[i + 1] - '0') * 10 + (s[i + 2] - '0');
    chmin(res, abs(753 - val));
  }
  cout << res << endl;
}