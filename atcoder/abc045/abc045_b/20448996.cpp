// detail: https://atcoder.jp/contests/abc045/submissions/20448996
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string a, b, c;
  cin >> a >> b >> c;
  vector<string> s{ a, b, c };
  int cur = 0;
  while (s[cur].size()) {
    var nxt = s[cur][0] - 'a';
    s[cur].erase(0, 1);
    cur = nxt;
  }
  cout << (char)('A' + cur) << endl;
}
