// detail: https://atcoder.jp/contests/agc003/submissions/20438221
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
  vector<bool> has(256);
  for (var&& c : s) has[c] = true;
  cout << ((has['N'] == has['S'] && has['W'] == has['E']) ? "Yes" : "No") << endl;
}
