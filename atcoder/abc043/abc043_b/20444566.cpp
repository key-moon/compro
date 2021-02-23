// detail: https://atcoder.jp/contests/abc043/submissions/20444566
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
  string buf = "";
  for (var&& c : s) {
    if (c == 'B') buf = buf.substr(0, buf.size() - 1);
    else buf += c;
  }
  cout << buf << endl;
}
