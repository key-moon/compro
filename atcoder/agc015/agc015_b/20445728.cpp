// detail: https://atcoder.jp/contests/agc015/submissions/20445728
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
  ll n = s.size();
  ll res = n * (n - 1);
  for (int i = 0; i < n; i++) {
    if (s[i] == 'U') res += i;
    else res += n - 1 - i;
  }
  cout << res << endl;
}
