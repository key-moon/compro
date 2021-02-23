// detail: https://atcoder.jp/contests/abc084/submissions/20436219
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b;
  cin >> a >> b;
  string s;
  cin >> s;
  var res = s[a] == '-';
  for (int i = 0; i <= a + b; i++) {
    if (i == a) continue;
    res &= '0' <= s[i] && s[i] <= '9';
  }
  cout << (res ? "Yes" : "No") << endl;
}