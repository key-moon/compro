// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2438/judge/6000848/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  string props_str;
  getline(cin, props_str);
  istringstream props_stream(props_str);
  string prop;
  queue<string> props;
  while (getline(props_stream, prop, '.')) {
    props.push(prop);
  }
  assert(props.front() == "");
  props.pop();
  int prev_depth = 0;
  string line;
  while (getline(cin, line)) {
    line = ' ' + line;
    if (line.size() < prev_depth) break;
    var indent = line.substr(0, prev_depth);
    line = line.substr(prev_depth);
    if (indent != string(prev_depth, ' ')) break;
    if (line[0] != ' ') break;
    
    int current_depth = prev_depth;
    while (line[0] == ' ') {
      line = line.substr(1);
      current_depth++;
    }

    var separator_at = line.find(':');
    assert(separator_at != string::npos);
    var prop = line.substr(0, separator_at);
    if (prop != props.front()) continue;

    props.pop();
    if (props.empty()) {
      string res;
      if (line.size() == separator_at + 1) res = "object";
      else {
        assert(separator_at + 2 < line.size());
        res = "string \"" + line.substr(separator_at + 2) + "\"";
      }
      cout << res << endl;
      return 0;
    }
    prev_depth = current_depth;
  }
  cout << "no such property" << endl;
  return 0;
}

