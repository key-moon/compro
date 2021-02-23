// detail: https://atcoder.jp/contests/abc062/submissions/20437223
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int h, w;
  cin >> h >> w;
  cout << string(w + 2, '#') << endl;
  for (int i = 0; i < h; i++) {
    string s;
    cin >> s;
    s = '#' + s + '#';
    cout << s << endl;
  }
  cout << string(w + 2, '#') << endl;
}
